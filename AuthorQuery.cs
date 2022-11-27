using graphql_server_db;
using graphql_server_models;
using Microsoft.EntityFrameworkCore;

namespace graphql_server_demo;

[ExtendObjectType(Name="Query")]
public class AuthorQuery
{
    public async Task<Author?> GetAuthor([Service(ServiceKind.Resolver)]DemoDbContext dbContext, int id)
    {
        return await dbContext.Authors
            .Include(x => x.Books)
                .ThenInclude(x => x.Book)
            .FirstOrDefaultAsync(x => x.AuthorId == id);
    }
    
    public async Task<List<Author>> GetAllAuthors([Service(ServiceKind.Resolver)]DemoDbContext dbContext)
    {
        return await dbContext.Authors
            .Include(x => x.Books)
                .ThenInclude(x => x.Book)
            .ToListAsync();
    }
}