using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeMusicManager.AlbumService.Model.Interfaces
{
    public interface IMongoRepository
    {
        public List<Album> GetAll();

        public Album GetById(Guid id);

        public Album Update(Album album);

        public Album Add(Album album);

        public void Delete(Guid id);
    }
}
