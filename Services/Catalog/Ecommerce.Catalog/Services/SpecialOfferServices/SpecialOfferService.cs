using AutoMapper;
using Ecommerce.Catalog.Dtos.SpecialOfferDtos;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;
using MongoDB.Driver;

namespace Ecommerce.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferSerivce
    {
        private readonly IMongoCollection<SpecialOffer> _SpecialOfferCollection;

        private readonly IMapper _mapper;

        // Ilk adim Baglanti ---> Database ---> Tablo

        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);///app.json icine _dbsetting ile eristik
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//database eristik
            _SpecialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);//tabloya ersitik
            _mapper = mapper;

        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _SpecialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _SpecialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);

        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOffer(string id)
        {
            var values = await _SpecialOfferCollection.Find(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(values);
        }

        public async Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync()
        {
            var values = await _SpecialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _SpecialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, values);
        }
    }
}
