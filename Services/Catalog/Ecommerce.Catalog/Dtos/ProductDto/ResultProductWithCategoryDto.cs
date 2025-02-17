using Ecommerce.Catalog.Dtos.CategoryDtos;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecommerce.Catalog.Dtos.ProductDto
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
