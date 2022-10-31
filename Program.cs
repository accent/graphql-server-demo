using graphql_server_db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer();
builder.Services.AddDbContext<DemoDbContext>(options => options.UseSqlServer());
var app = builder.Build();

app.MapGraphQL();
app.Run();