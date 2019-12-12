using System;
using AwesomeMusicManager.AlbumService.Model;
using AwesomeMusicManager.AlbumService.Model.Interfaces;
using Moq;
using Xunit;

namespace AwesomeMusicManager.AlbumService.Tests
{
    public class AlbumServiceTests
    {
        private readonly Service.AlbumService _service;
        private readonly Mock<IMongoRepository> _repositoryMock = new Mock<IMongoRepository>();
        
        public AlbumServiceTests()
        {
            _service = new Service.AlbumService(_repositoryMock.Object);
        }
        
        [Fact]
        public void TestAdd()
        {
            var album = new Album
            {
                Band = "Test band",
                Title = "Test title",
                Url = "Test url",
                VagalumeId = "10"
            };

            _service.Add(album);
            _repositoryMock.Verify(x => x.Add(album), Times.Once());
        }
        
        [Fact]
        public void TestUpdate()
        {
            var album = new Album
            {
                Id = Guid.NewGuid().ToString(),
                Band = "Test band",
                Title = "Test title",
                Url = "Test url",
                VagalumeId = "10"
            };

            _service.Update(album);
            _repositoryMock.Verify(x => x.Update(album), Times.Once());
        }
        
        [Fact]
        public void TestDelete()
        {
            var id = Guid.NewGuid();

            _service.Delete(id);
            _repositoryMock.Verify(x => x.Delete(id), Times.Once());
        }
        
        [Fact]
        public void TestGetAll()
        {
            _service.GetAll();
            _repositoryMock.Verify(x => x.GetAll(), Times.Once());
        }
        
        [Fact]
        public void TestGetById()
        {
            var id = Guid.NewGuid();

            _service.GetById(id);
            _repositoryMock.Verify(x => x.GetById(id), Times.Once());
        }
    }
}
