using AwesomeMusicManager.AlbumService.Infrastructure;
using AwesomeMusicManager.AlbumService.Model;
using AwesomeMusicManager.AlbumService.Model.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeMusicManager.AlbumService.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IMongoRepository _repository;

        public AlbumService(IMongoRepository repository)
        {
            _repository = repository;
        }

        public List<Album> GetAll()
        {
            List<Album> albums = _repository.GetAll();
            return albums;
        }

        public Album GetById(Guid id)
        {
            var album = _repository.GetById(id);
            return album;
        }

        public Album Update(Album album)
        {
            _repository.Update(album);
            return album;
        }

        public Album Add(Album album)
        {
            _repository.Add(album);
            return album;
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
