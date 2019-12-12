using System;
using System.Collections.Generic;
using AwesomeMusicManager.AlbumService.Model;
using AwesomeMusicManager.AlbumService.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomeMusicManager.AlbumService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private ILogger<AlbumController> _logger;

        public AlbumController(IAlbumService service, ILogger<AlbumController> logger)
        {
            _albumService = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Iniciado fluxo de busca de todos os albuns");
            List<Album> albums = _albumService.GetAll();
            return Ok(albums);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Edit(Guid id)
        {
            _logger.LogInformation("Iniciado fluxo de atualização de álbum");
            var album = _albumService.GetById(id);
            return Ok(album);
        }

        [HttpPut]
        public IActionResult Edit(Album album)
        {
            _logger.LogInformation("Iniciado fluxo de edição de álbum");
            _albumService.Update(album);
            return Ok(album);
        }

        [HttpPost]
        public IActionResult Add(Album album)
        {
            _logger.LogInformation("Iniciado fluxo de adição de álbum");
            var insertedAlbum = _albumService.Add(album);
            return Ok(insertedAlbum);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation("Iniciado fluxo de deleção de álbum");
            _albumService.Delete(id);
            return Ok();
        }
    }
}
