using Microsoft.EntityFrameworkCore;
using PP_BC_C_H_3_1.Models.Domain;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships if needed
            modelBuilder.Entity<Book>()
                .HasOne<Genre>()
                .WithMany()
                .HasForeignKey(x => x.GenreId);

            // You can add seed data here if needed

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fiction" },
                new Genre { Id = 2, Name = "Non-Fiction" },
                new Genre { Id = 3, Name = "Science Fiction" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Fiction", GenreId = 1, PageCount = 10, PublishDate = DateTime.Now.AddMonths(-3) },
                new Book { Id = 2, Title = "Non-Fiction", GenreId = 2, PageCount = 20, PublishDate = DateTime.Now.AddYears(-3) },
                new Book { Id = 3, Title = "Science Fiction", GenreId = 3, PageCount = 30, PublishDate = DateTime.Now.AddDays(-21) }
            );



            base.OnModelCreating(modelBuilder);
        }
    }
}
