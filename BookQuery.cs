using graphql_server_db;
using graphql_server_models;
using Microsoft.EntityFrameworkCore;

namespace graphql_server_demo;

[ExtendObjectType(Name="Query")]
public class BookQuery
{
    private readonly DemoDbContext _context;

    public BookQuery(DemoDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Book?> GetBook(int id)
    {
        return await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
    }
    
    public async Task<List<Book>> GetAll()
    {
        return await _context.Books.ToListAsync();
    }
}