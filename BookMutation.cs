using graphql_server_db;
using Microsoft.EntityFrameworkCore;

namespace graphql_server_demo;

[ExtendObjectType(Name="Mutation")]
public class BookMutation
{
    public async Task<bool> RemoveBook([Service(ServiceKind.Resolver)]DemoDbContext dbContext,[ID] int id)
    {
        var book = await dbContext.Books.FirstOrDefaultAsync(x => x.BookId == id);
        if (book != null)
        {
            dbContext.Books.Remove(book);
            await dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}