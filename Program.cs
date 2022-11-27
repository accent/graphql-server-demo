using graphql_server_db;
using graphql_server_demo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
    .RegisterDbContext<DemoDbContext>(DbContextKind.Synchronized)
    .AddQueryType(q => q.Name("Query"))
    .AddType<AuthorQuery>()
    .AddType<BookQuery>();

builder.Services.AddDbContext<DemoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.MapGraphQL();
app.Run();