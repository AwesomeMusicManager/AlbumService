using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AwesomeMusicManager.AlbumService.Model
{
    public class Album
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        public string VagalumeId { get; set; }

        [Required]
        public string Url { get; set; }

        public string Title { get; set; }

        [Required]
        public string Band { get; set; }
    }
}
