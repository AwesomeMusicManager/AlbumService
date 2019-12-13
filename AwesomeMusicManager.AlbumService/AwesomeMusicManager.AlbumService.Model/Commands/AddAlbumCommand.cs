using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AwesomeMusicManager.AlbumService.Model.Commands
{
    public class AddAlbumCommand : Album, IRequest<AddAlbumCommand>
    {
    }
}
