namespace graphql_server_models;

public record Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public IEnumerable<AuthorBook> Authors { get; set; }
}