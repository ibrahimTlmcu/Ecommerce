using AutoMapper;
using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Dtos.ProductDetailDtos;

using Ecommerce.Catalog.Dtos.ProductDto;
using Ecommerce.Catalog.Dtos.ProductImageDto;
using Ecommerce.Catalog.Entities;

namespace Ecommerce.Catalog.Mapping
{
    #region MapperAçıklamam
        //yapıcı meot içinde çalışır.
        //entitylerden nesne oluiutmrak yerine yani  newlemek yerine
        //bu propertyleri dto da ki propertylerle eşlemek için 
        //ReverseMap() ayni islemin ters tarafli calimasi icin gerekli

    #endregion
    public class GeneralMapping : Profile 
    {
        public GeneralMapping() 
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateCategoryDto>().ReverseMap();
            CreateMap<Product,UpdateCategoryDto>().ReverseMap();
            CreateMap<Product,GetByIdCategoryDto>().ReverseMap();


            CreateMap<ProductDetail,ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImages,ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImages,CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductImages,UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductImages,GetByIdProductDetailDto>().ReverseMap();




        }
    }
}
