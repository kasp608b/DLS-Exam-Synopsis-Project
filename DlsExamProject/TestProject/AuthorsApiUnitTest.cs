using AuthorsApi.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class AuthorsApiUnitTest
    {
        [Fact]
        public void TestAuthorConverterFromAuthorToAuthorDto()
        {
            {
                var authorConverter = new AuthorConverter();

                var author = new Author
                {
                    _id = "1",
                    Name = "Test"
                };

                var authorDto = new AuthorDto
                {
                    _id = "1",
                    Name = "Test"
                };

                var convertedAuthorDto = authorConverter.Convert(author);

                Assert.Equal(authorDto._id, convertedAuthorDto._id);
                Assert.Equal(authorDto.Name, convertedAuthorDto.Name);
            }
        }

        [Fact]
        public void TestAuthorConverterFromAuthorDtoToAuthor()
        {
            {
                var authorConverter = new AuthorConverter();

                var author = new Author
                {
                    _id = "1",
                    Name = "Test"
                };

                var authorDto = new AuthorDto
                {
                    _id = "1",
                    Name = "Test"
                };

                var convertedAuthor = authorConverter.Convert(authorDto);

                Assert.Equal(author._id, convertedAuthor._id);
                Assert.Equal(author.Name, convertedAuthor.Name);
            }
            
        }
    }
}
