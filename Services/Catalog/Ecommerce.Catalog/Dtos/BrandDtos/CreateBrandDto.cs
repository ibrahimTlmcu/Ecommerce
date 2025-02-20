using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Ecommerce.Catalog.Dtos.BrandDtos
{
    public class CreateBrandDto
    {
       
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
