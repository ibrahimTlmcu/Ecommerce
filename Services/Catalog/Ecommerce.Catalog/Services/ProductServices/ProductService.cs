using AutoMapper;
using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Dtos.ProductDto;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;
using MongoDB.Driver;

namespace Ecommerce.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

      

        public async Task<GetByIdProductDto> GetByIdProduct(string id)
        {
            var values = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);  

        }

        //public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync(string CategoryId)
        //{
        //    var values = await _productCollection.Find(x => true).ToListAsync();
        //    foreach(var item in values)
        //    {
        //        item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
        //    };

        //    return _mapper.Map<List<ResultProductWithCategoryDto>>(values);


        //}

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {

            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstAsync();
            };

            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);

        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryId==CategoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            

            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);

        }

        public async Task<List<ResultProductDto>> GettAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values); 
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);

        }
    }
}
