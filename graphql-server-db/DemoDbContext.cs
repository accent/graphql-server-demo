using graphql_server_models;
using Microsoft.EntityFrameworkCore;

namespace graphql_server_db;

public class DemoDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    
    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasKey(x => x.AuthorId);
        
        modelBuilder.Entity<Author>()
            .Property(x => x.AuthorId).ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Book>()
            .HasKey(x => x.BookId);
        
        modelBuilder.Entity<Book>()
            .Property(x => x.BookId).ValueGeneratedOnAdd();

        modelBuilder.Entity<Book>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.Books);
        
        modelBuilder.Entity<Author>()
            .HasMany(x => x.Books)
            .WithMany(x => x.Authors);
    }
}