using System;
using System.Collections.Generic;
using AwesomeMusicManager.AlbumService.Model;
using AwesomeMusicManager.AlbumService.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeMusicManager.AlbumService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService service)
        {
            _albumService = service;
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
        public IActionResult Edit(Album album)
        {
            _albumService.Update(album);
            return Ok(album);
        }

        [HttpPost]
        public IActionResult Add(Album album)
        {
            var insertedAlbum = _albumService.Add(album);
            return Ok(insertedAlbum);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _albumService.Delete(id);
            return Ok();
        }
    }
}
