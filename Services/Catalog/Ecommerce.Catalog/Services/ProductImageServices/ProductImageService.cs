using AutoMapper;
using Ecommerce.Catalog.Dtos.ProductImageDto;
using Ecommerce.Catalog.Settings;
using Ecommerce.Catalog.Entities;
using MongoDB.Driver;

namespace Ecommerce.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImages> _ProductImageCollection;

        private readonly IMapper _mapper;

        // Ilk adim Baglanti ---> Database ---> Tablo

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);///app.json icine _dbsetting ile eristik
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//database eristik
            _ProductImageCollection = database.GetCollection<ProductImages>(_databaseSettings.ProductImageCollectionName);//tabloya ersitik
            _mapper = mapper;

        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImages>(createProductImageDto);
            await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x => x.ProductImagesId == id);

        }

        public async Task<GetByIdProductImageDto> GetByIdProductImage(string id)
        {
            var values = await _ProductImageCollection.Find(x => x.ProductImagesId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<List<ResultProductImageDto>> GettAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImages>(UpdateProductImageAsync);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImagesId == updateProductImageDto.ProductImagesId, values);
        }

    }
}
