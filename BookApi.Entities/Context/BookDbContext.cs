//using BookApi.Entities.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace BookApi.Entities.Context
//{
//    public class BookDbContext : DbContext
//    {
//        public BookDbContext(DbContextOptions<BookDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<BookDetails> BookDetails { get; set; }
//    }
//}


using BookApi.Entities.Entities; // This should point to where BookDetails is located
using Microsoft.EntityFrameworkCore;

namespace BookApi.Entities.Context // Keep this namespace as is
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        // Initialize DbSet with null-forgiving operator to suppress CS8618
        public DbSet<BookDetails> BookDetails { get; set; } = null!;

        // Add this if you're using Fluent API configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entities here if needed
            // Example:
            // modelBuilder.Entity<BookDetails>().Property(b => b.Title).IsRequired();
        }
    }
}