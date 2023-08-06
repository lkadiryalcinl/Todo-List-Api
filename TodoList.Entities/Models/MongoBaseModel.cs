using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Entities.Models
{
    public class MongoBaseModel
    {
        public ObjectId _id { get; set; }
        [BsonElement("todoID")]
        public int TodoID { get; set; }
        [BsonElement("userID")]
        public int UserID { get; set; }
        [BsonElement("isFinished")]
        public Boolean IsFinished { get; set; }
        [BsonElement("isFav")]
        public Boolean IsFav { get; set; }
        [BsonElement("isActive")]
        public Boolean IsActive { get; set; } = true;

    }
}
