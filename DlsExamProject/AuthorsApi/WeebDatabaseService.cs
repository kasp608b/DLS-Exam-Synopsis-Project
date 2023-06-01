using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeebAPI.Models;

namespace WeebAPI.Services
{
    public class WeebDatabaseService
    {
        private readonly IMongoCollection<Weeb> _weebCollection;

        public WeebDatabaseService(IOptions<WeebDatabaseSettings> weebDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            weebDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                weebDatabaseSettings.Value.DatabaseName);

            _weebCollection = mongoDatabase.GetCollection<Weeb>(
                weebDatabaseSettings.Value.WeebCollectionName);
        }

        public async Task<List<Weeb>> GetAsync() =>
       await _weebCollection.Find(_ => true).ToListAsync();

        public async Task<Weeb?> GetAsync(string id) =>
            await _weebCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task<Weeb> CreateAsync(Weeb newWeeb)
        {
            await _weebCollection.InsertOneAsync(newWeeb);
            return newWeeb;
        }

        public async Task UpdateAsync(string id, Weeb updatedWeeb) =>
            await _weebCollection.ReplaceOneAsync(x => x._id == id, updatedWeeb);

        public async Task RemoveAsync(string id) =>
            await _weebCollection.DeleteOneAsync(x => x._id == id);
    }


}
