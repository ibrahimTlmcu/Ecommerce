﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Ecommerce.Catalog.Entities
{
    public class ProductImages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string  ProductImagesId { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
