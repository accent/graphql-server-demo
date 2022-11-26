using graphql_server_db;
using graphql_server_demo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
    .AddType<AuthorQuery>()
    .AddType<BookQuery>();

builder.Services.AddDbContext<DemoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), contextLifetime: ServiceLifetime.Transient);
var app = builder.Build();
app.MapGraphQL();
app.Run();