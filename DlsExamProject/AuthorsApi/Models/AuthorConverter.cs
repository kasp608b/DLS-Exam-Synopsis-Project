using Common;

namespace AuthorsApi.Models
{
    public class AuthorConverter : IConverter<Author, AuthorDto>
    {
        public Author Convert(AuthorDto model)
        {
            return new Author
            {
                _id = model._id,
                Name = model.Name
            };
        }

        public AuthorDto Convert(Author model)
        {
            return new AuthorDto
            {
                _id = model._id,
                Name = model.Name
            };
        }
    }
}
