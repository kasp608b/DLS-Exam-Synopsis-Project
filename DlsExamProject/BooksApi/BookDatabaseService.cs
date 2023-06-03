using BooksApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BooksApi
{
    public class BookDatabaseService
    {
        private readonly IMongoCollection<Book> _bookCollection;

        public BookDatabaseService(IOptions<BookDatabaseSettings> bookdatabaseSettings)
        {
            var mongoClient = new MongoClient(
            bookdatabaseSettings.Value.ConnectionString);

            Console.WriteLine(bookdatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookdatabaseSettings.Value.DatabaseName);

            _bookCollection = mongoDatabase.GetCollection<Book>(
                bookdatabaseSettings.Value.BookCollectionName);
        }

        public async Task<List<Book>> GetAsync() =>
       await _bookCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) =>
            await _bookCollection.Find(x => x._id == id).FirstOrDefaultAsync();
        public async Task<List<Book>> GetAsyncByAuthor(string id) =>
            await _bookCollection.Find(x => x.Authorid == id).ToListAsync();

        public async Task<Book> CreateAsync(Book newBook)
        {
            await _bookCollection.InsertOneAsync(newBook);
            return newBook;
        }

        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _bookCollection.ReplaceOneAsync(x => x._id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _bookCollection.DeleteOneAsync(x => x._id == id);
    }
}
