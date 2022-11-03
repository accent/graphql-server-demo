using graphql_server_db;
using graphql_server_models;
using Microsoft.EntityFrameworkCore;

namespace graphql_server_demo;

public class AuthorQuery
{
    private readonly DemoDbContext _context;

    public AuthorQuery(DemoDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Author?> GetAuthor(int id)
    {
        return await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
    }
    
    public async Task<List<Author>> GetAll()
    {
        return await _context.Authors.ToListAsync();
    }
}