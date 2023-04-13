using BookHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataProvider
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        /// <summary>   
        /// This is for getting entities by type from data base.
        /// </summary>   
        public IQueryable<T> GetEntities<T>() where T : IEntity => Set<T>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(b => b.Id);

            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(b => b.Id);

                b.HasOne<Category>(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
