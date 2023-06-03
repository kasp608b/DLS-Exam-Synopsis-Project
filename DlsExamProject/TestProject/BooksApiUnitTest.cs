using BooksApi.Models;
using Common;

namespace TestProject
{
    public class BooksApiUnitTest
    {
        [Fact]
        public void TestBookConverterFromBookToBookDto()
        {
            var bookConverter = new BookConverter();

            var book = new Book
            {
                _id = "1",
                Title = "Test",
                Genre = "Test",
                Description = "Test",
                Authorid = "1"
            };

            var bookDto = new BookDto
            {
                _id = "1",
                Title = "Test",
                Genre = "Test",
                Description = "Test",
                Authorid = "1"
            };

            var convertedBookDto = bookConverter.Convert(book);

            Assert.Equal(bookDto._id, convertedBookDto._id);
            Assert.Equal(bookDto.Title, convertedBookDto.Title);
            Assert.Equal(bookDto.Genre, convertedBookDto.Genre);
            Assert.Equal(bookDto.Description, convertedBookDto.Description);
            Assert.Equal(bookDto.Authorid, convertedBookDto.Authorid);

        }

        [Fact]
        public void TestBookConverterFromBookDtoToBook()
        {
            var bookConverter = new BookConverter();

            var book = new Book
            {
                _id = "1",
                Title = "Test",
                Genre = "Test",
                Description = "Test",
                Authorid = "1"
            };

            var bookDto = new BookDto
            {
                _id = "1",
                Title = "Test",
                Genre = "Test",
                Description = "Test",
                Authorid = "1"
            };

            var convertedBook = bookConverter.Convert(bookDto);

            Assert.Equal(book._id, convertedBook._id);
            Assert.Equal(book.Title, convertedBook.Title);
            Assert.Equal(book.Genre, convertedBook.Genre);
            Assert.Equal(book.Description, convertedBook.Description);
            Assert.Equal(book.Authorid, convertedBook.Authorid);


        }
    }
}