namespace Common
{
    public class AuthorDto
    {
        public string? _id { get; set; }

        public string Name { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
