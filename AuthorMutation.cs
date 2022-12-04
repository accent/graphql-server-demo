using graphql_server_db;
using Microsoft.EntityFrameworkCore;

namespace graphql_server_demo;

[ExtendObjectType(Name="Mutation")]
public class AuthorMutation
{
    public async Task<bool> RemoveAuthor([Service(ServiceKind.Resolver)]DemoDbContext dbContext, [ID] int id)
    {
        var author = await dbContext.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
        if (author != null)
        {
            dbContext.Authors.Remove(author);
            await dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}