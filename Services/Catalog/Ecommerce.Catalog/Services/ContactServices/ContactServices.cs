using AutoMapper;
using Ecommerce.Catalog.Dtos.ContactDtos;
using Ecommerce.Catalog.Dtos.ContactDtos;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;
using MongoDB.Driver;

namespace Ecommerce.Catalog.Services.ContactServices
{
    public class ContactServices : IContactServices
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        private readonly IMapper _mapper;

        // Ilk adim Baglanti ---> Database ---> Tablo

        public ContactServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);///app.json icine _dbsetting ile eristik
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//database eristik
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);//tabloya ersitik
            _mapper = mapper;

        }
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);

        }


        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var values = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(values);
        }


        public async Task<List<ResultContactDto>> GettAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId== updateContactDto.ContactId, values);
        }
    }
}
