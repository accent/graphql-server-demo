using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace graphql_server_db.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                declare @auth1 int
                  INSERT INTO Authors ([FirstName], [LastName], [BirthDate], [DeathDate]) VALUES ('Jan', 'Kapela', cast('1984-01-01' as datetime2), null)
                  select @auth1 = @@IDENTITY
                  declare @auth2 int
                  INSERT INTO Authors ([FirstName], [LastName], [BirthDate], [DeathDate]) VALUES ('Stanisław', 'Lem', cast('1921-09-13' as datetime2), cast('2006-03-27' as datetime2))
                  select @auth2 = @@IDENTITY
                  declare @book1 int
                  INSERT INTO Books ([Title], [Isbn]) VALUES ('Book title1', '1-233-3423-4')
                  select @book1 = @@IDENTITY
                  declare @book2 int
                  INSERT INTO Books ([Title], [Isbn]) VALUES ('Book title2', '1-233-7423-1')
                  select @book2 = @@IDENTITY
                  declare @book3 int
                  INSERT INTO Books ([Title], [Isbn]) VALUES ('Book title3', '1-673-1423-4')
                  select @book3 = @@IDENTITY
                  INSERT INTO AuthorBook ([AuthorsAuthorId],[BooksBookId]) VALUES (@auth1, @book1), (@auth2, @book2), (@auth1, @book3), (@auth2, @book3)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
