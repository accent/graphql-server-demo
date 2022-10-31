namespace graphql_server_models;

public record Author
{
    public Guid AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public IEnumerable<Book> Books { get; set; }
}