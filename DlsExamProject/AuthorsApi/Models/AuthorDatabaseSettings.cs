namespace AuthorsApi.Models
{
    public class AuthorDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AuthorCollectionName { get; set; } = null!;

    }
}
