using AwesomeMusicManager.AlbumService.Infrastructure;
using AwesomeMusicManager.AlbumService.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeMusicManager.AlbumService.Service
{
    public class AlbumService
    {
        private readonly MongoRepository repository;

        public AlbumService()
        {
            repository = new MongoRepository();
        }

        public List<Album> GetAll()
        {
            List<Album> albums = repository.Albums.Find(m => true).ToList();
            return albums;
        }

        public Album GetById(Guid id)
        {
            var album = repository.Albums.Find(m => m.Id == id.ToString()).FirstOrDefault();
            return album;
        }

        public Album Update(Album album)
        {
            repository.Albums.ReplaceOne(m => m.Id == album.Id, album);
            return album;
        }

        public Album Add(Album album)
        {
            album.Id = Guid.NewGuid().ToString();
            repository.Albums.InsertOne(album);
            return album;
        }

        public void Delete(Guid id)
        {
            repository.Albums.DeleteOne(m => m.Id == id.ToString());
        }
    }
}
