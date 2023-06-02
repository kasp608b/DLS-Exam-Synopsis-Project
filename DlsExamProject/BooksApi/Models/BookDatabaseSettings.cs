namespace BooksApi.Models
{
    public class BookDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BookCollectionName { get; set; } = null!;
    }
}
