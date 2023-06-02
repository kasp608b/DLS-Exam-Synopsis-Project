using Common;

namespace BooksApi.Models
{
    public class BookConverter : IConverter<Book, BookDto>
    {
        public Book Convert(BookDto bookDto)
        {
            return new Book
            {
                _id = bookDto._id,
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                Description = bookDto.Description,
                Authorid = bookDto.Authorid
            };
        }

        public BookDto Convert(Book book)
        {
            return new BookDto
            {
                _id = book._id,
                Title = book.Title,
                Genre = book.Genre,
                Description = book.Description,
                Authorid = book.Authorid
            };
        }
    }
}
