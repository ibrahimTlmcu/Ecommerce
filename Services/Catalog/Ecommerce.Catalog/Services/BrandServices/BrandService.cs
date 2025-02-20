using AutoMapper;
using Ecommerce.Catalog.Dtos.BrandDtos;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;

using MongoDB.Driver;

namespace Ecommerce.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _BrandCollection;

        private readonly IMapper _mapper;

        // Ilk adim Baglanti ---> Database ---> Tablo

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);///app.json icine _dbsetting ile eristik
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//database eristik
            _BrandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);//tabloya ersitik
            _mapper = mapper;

        }
        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto);
            await _BrandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _BrandCollection.DeleteOneAsync(x => x.BrandId == id);

        }

        public async Task<GetByIdBrandDto> GetByIdBrand(string id)
        {
            var values = await _BrandCollection.Find(x => x.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(values);
        }

        public async Task<List<ResultBrandDto>> GettAllBrandAsync()
        {
            var values = await _BrandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var values = _mapper.Map<Brand>(updateBrandDto);
            await _BrandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, values);
        }
    }
}
