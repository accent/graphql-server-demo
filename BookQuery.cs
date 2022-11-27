using graphql_server_db;
using graphql_server_models;
using Microsoft.EntityFrameworkCore;

namespace graphql_server_demo;

[ExtendObjectType(Name="Query")]
public class BookQuery
{
    public async Task<Book?> GetBook([Service(ServiceKind.Synchronized)]DemoDbContext dbContext, int id)
    {
        return await dbContext.Books
            .Include(x => x.Authors)
                .ThenInclude(x => x.Author)
            .SingleOrDefaultAsync(x => x.BookId == id);
    }
    
    public async Task<List<Book>> GetAllBooks([Service(ServiceKind.Synchronized)]DemoDbContext dbContext)
    {
        return await dbContext.Books
            .Include(x => x.Authors)
                .ThenInclude(x => x.Author)
            .ToListAsync();
    }
}