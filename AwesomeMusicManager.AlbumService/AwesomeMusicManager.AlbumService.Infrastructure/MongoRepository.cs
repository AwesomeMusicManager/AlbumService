using AwesomeMusicManager.AlbumService.Model;
using AwesomeMusicManager.AlbumService.Model.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AwesomeMusicManager.AlbumService.Infrastructure
{
    public class MongoRepository : IMongoRepository
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database { get; }

        public MongoRepository()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<Album> Albums
        {
            get
            {
                return _database.GetCollection<Album>("Albuns");
            }
        }

        public List<Album> GetAll()
        {
            List<Album> albums = Albums.Find(m => true).ToList();
            return albums;
        }

        public Album GetById(Guid id)
        {
            var album = Albums.Find(m => m.Id == id.ToString()).FirstOrDefault();
            return album;
        }

        public Album Update(Album album)
        {
            Albums.ReplaceOne(m => m.Id == album.Id, album);
            return album;
        }

        public Album Add(Album album)
        {
            album.Id = Guid.NewGuid().ToString();
            Albums.InsertOne(album);
            return album;
        }

        public void Delete(Guid id)
        {
            Albums.DeleteOne(m => m.Id == id.ToString());
        }
    }
}
