using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoryPicker.Core
{
    public class Comment
    {
        [BsonId]
        public ObjectId CommentId { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        [Required]
        public string Detail { get; set; }
    }
 }

