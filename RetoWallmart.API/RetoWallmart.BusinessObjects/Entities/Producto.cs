using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetoWallmart.BusinessObjects
{
    public class Producto_Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public long id { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public double price { get; set; }

    }
}
