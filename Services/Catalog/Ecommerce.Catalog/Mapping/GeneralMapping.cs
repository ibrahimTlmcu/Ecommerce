using AutoMapper;
using Ecommerce.Catalog.Dtos.AboutDto;
using Ecommerce.Catalog.Dtos.BrandDtos;
using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Dtos.FeatureDtos;
using Ecommerce.Catalog.Dtos.FeatureSliderDtos;
using Ecommerce.Catalog.Dtos.OfferDiscountDtos;
using Ecommerce.Catalog.Dtos.ProductDetailDtos;

using Ecommerce.Catalog.Dtos.ProductDto;
using Ecommerce.Catalog.Dtos.ProductImageDto;
using Ecommerce.Catalog.Dtos.SpecialOfferDtos;
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
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetByIdProductDto>().ReverseMap();



            CreateMap<ProductDetail,ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImages,ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImages,CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImages,UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImages,GetByIdProductImageDto>().ReverseMap();

            CreateMap<Product,ResultProductWithCategoryDto>().ReverseMap();



            CreateMap<FeatureSlider,ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();


            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();


            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
        }
    }
}
