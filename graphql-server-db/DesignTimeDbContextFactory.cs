using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace graphql_server_db;

public class DesignTimeDbContextFactory
{
    public DemoDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<DemoDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);
        return new DemoDbContext(builder.Options);
    }
}