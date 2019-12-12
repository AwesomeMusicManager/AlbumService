using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeMusicManager.AlbumService.Model.Interfaces
{
    public interface IAlbumService
    {
        List<Album> GetAll();

        Album GetById(Guid id);

        Album Update(Album album);

        Album Add(Album album);

        void Delete(Guid id);
    }
}
