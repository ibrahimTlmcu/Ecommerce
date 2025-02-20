 using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecommerce.Catalog.Entities
{
    public class Category
    {
        /// <summary>
        /// Mongodb olduğu için idler string 
        /// ve bson ile blirtilir  
        /// </summary>
        /// 

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
