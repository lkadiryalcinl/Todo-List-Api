using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TodoList.Entities.Models
{
    public class FinTodoMongoModel:MongoBaseModel
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
