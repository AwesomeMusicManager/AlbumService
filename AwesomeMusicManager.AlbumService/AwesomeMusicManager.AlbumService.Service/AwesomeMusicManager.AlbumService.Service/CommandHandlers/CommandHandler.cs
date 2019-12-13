using AwesomeMusicManager.AlbumService.Model;
using AwesomeMusicManager.AlbumService.Model.Commands;
using AwesomeMusicManager.AlbumService.Model.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeMusicManager.AlbumService.Service.CommandHandlers
{
    public class CommandHandler : 
        IRequestHandler<AddAlbumCommand, Album>, 
        IRequestHandler<EditAlbumCommand, Album>
    {
        private readonly IAlbumService _service;

        public CommandHandler(IAlbumService service)
        {
            _service = service;
        }

        public Task<Album> Handle(AddAlbumCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.Add(command));
        }

        public Task<Album> Handle(EditAlbumCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.Update(command));
        }
    }
}
