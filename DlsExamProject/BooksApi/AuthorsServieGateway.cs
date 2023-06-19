using Common;
using RestSharp;

namespace BooksApi
{
    public class AuthorsServiceGateway
    {
        string _AuthorServiceUrl;

        public AuthorsServiceGateway(string AuthorServiceUrl)
        {
            _AuthorServiceUrl = AuthorServiceUrl;
        }

        public async Task<AuthorDto> Get(string authorId)
        {
            RestClient c = new RestClient(_AuthorServiceUrl);
            var request = new RestRequest(authorId);
            return await c.GetAsync<AuthorDto>(request);
        }

    }
}
