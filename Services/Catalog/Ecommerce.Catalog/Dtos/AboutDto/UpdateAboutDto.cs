using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Ecommerce.Catalog.Dtos.AboutDto
{
    public class UpdateAboutDto
    {
        public string AboutId { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
