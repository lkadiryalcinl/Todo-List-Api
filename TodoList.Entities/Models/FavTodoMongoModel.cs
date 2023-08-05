using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoList.Entities.Models
{
    [BsonIgnoreExtraElements]
    public class FavTodoMongoModel : MongoBaseModel
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("priorityType")]
        public string PriorityType { get; set; }

        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set; }

        [BsonElement("dateStart")]
        public DateTime DateStart { get; set; }

        [BsonElement("dateEnd")]
        public DateTime DateEnd { get; set; }

    }
}
