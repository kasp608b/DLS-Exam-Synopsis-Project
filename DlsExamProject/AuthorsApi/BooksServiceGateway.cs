using Common;
using RestSharp;

namespace AuthorsApi
{
    public class BooksServiceGateway
    {
        string AuthorServiceBaseUrl;

        public BooksServiceGateway(string baseUrl)
        {
            AuthorServiceBaseUrl = baseUrl;
        }

        public Task<List<BookDto>?> GetBooksByAuthor(string AuthorId)
        {
            RestClient c = new RestClient(AuthorServiceBaseUrl);
            var request = new RestRequest($"GetbooksByAuthor/{AuthorId}");
            return c.GetAsync<List<BookDto>>(request);

        }
    }
}
