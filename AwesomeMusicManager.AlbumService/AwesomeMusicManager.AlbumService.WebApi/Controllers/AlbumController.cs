using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeMusicManager.AlbumService.Model;
using AwesomeMusicManager.AlbumService.Model.Commands;
using AwesomeMusicManager.AlbumService.Model.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeMusicManager.AlbumService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IMediator _mediator;


        public AlbumController(IAlbumService service, IMediator mediator)
        {
            _albumService = service;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Album> albums = _albumService.GetAll();
            return Ok(albums);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Edit(Guid id)
        {
            var album = _albumService.GetById(id);
            return Ok(album);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditAlbumCommand command)
        {
            var response = await _mediator.Send<EditAlbumCommand>(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAlbumCommand command)
        {
            var response = await _mediator.Send<AddAlbumCommand>(command);

            return Ok(response);

            //var insertedAlbum = _albumService.Add(album);
            //return Ok(insertedAlbum);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _albumService.Delete(id);
            return Ok();
        }
    }
}
