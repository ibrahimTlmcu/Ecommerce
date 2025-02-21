using AutoMapper;
using Ecommerce.Catalog.Dtos.AboutDto;

using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Ecommerce.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _AboutCollection;

        private readonly IMapper _mapper;

        // Ilk adim Baglanti ---> Database ---> Tablo

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);///app.json icine _dbsetting ile eristik
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//database eristik
            _AboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);//tabloya ersitik
            _mapper = mapper;

        }
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _AboutCollection.InsertOneAsync(value);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _AboutCollection.DeleteOneAsync(x => x.AboutId == id);

        }

        public async Task<GetByIdAboutDto> GetByIdAbout(string id)
        {
            var values = await _AboutCollection.Find(x => x.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(values);
        }

        public async Task<List<ResultAboutDto>> GettAllAboutAsync()
        {
            var values = await _AboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }
       
        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            await _AboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, values);
        }
    }
}

