using graphql_server_db;
using graphql_server_demo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
    .AddQueryType<AuthorQuery>()
    .AddQueryType<BookQuery>();
builder.Services.AddDbContext<DemoDbContext>(options => options.UseSqlServer());
var app = builder.Build();

app.MapGraphQL();
app.Run();