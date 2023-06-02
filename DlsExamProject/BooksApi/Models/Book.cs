namespace BooksApi.Models
{
    public class Book
    {
        public string? _id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Authorid { get; set; }
    }
}
