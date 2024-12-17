using Microsoft.EntityFrameworkCore;

namespace BooksManagementSystem.Common
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> books { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<User> user { get; set; }
    }
}
