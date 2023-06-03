using AuthorsApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AuthorsApi
{
    public class AuthorDatabaseService
    {
        private readonly IMongoCollection<Author> _authorCollection;

        public AuthorDatabaseService(IOptions<AuthorDatabaseSettings> authorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            authorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                authorDatabaseSettings.Value.DatabaseName);

            _authorCollection = mongoDatabase.GetCollection<Author>(
                authorDatabaseSettings.Value.AuthorCollectionName);
        }

        public async Task<List<Author>> GetAsync() =>
       await _authorCollection.Find(_ => true).ToListAsync();

        public async Task<Author?> GetAsync(string id) =>
            await _authorCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task<Author> CreateAsync(Author newAuthor)
        {
            await _authorCollection.InsertOneAsync(newAuthor);
            return newAuthor;
        }

        public async Task UpdateAsync(string id, Author updatedAuthor) =>
            await _authorCollection.ReplaceOneAsync(x => x._id == id, updatedAuthor);

        public async Task RemoveAsync(string id) =>
            await _authorCollection.DeleteOneAsync(x => x._id == id);
    }


}
