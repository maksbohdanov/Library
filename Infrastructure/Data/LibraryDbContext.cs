using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().HasKey(p => p.ID);
            modelBuilder.Entity<Book>().Property(p => p.ID).ValueGeneratedOnAdd();

            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Name = "To Kill a Mockingbird",
                    PublishingDate = new DateTime(1960, 7, 11),
                    Description = "A classic novel by Harper Lee.",
                    Pages = 281
                },
                new Book
                {
                    Name = "1984",
                    PublishingDate = new DateTime(1949, 6, 8),
                    Description = "A dystopian novel by George Orwell.",
                    Pages = 328
                },
                new Book
                {
                    Name = "The Great Gatsby",
                    PublishingDate = new DateTime(1925, 4, 10),
                    Description = "A novel by F. Scott Fitzgerald.",
                    Pages = 180
                },
                new Book
                {
                    Name = "Pride and Prejudice",
                    PublishingDate = new DateTime(1813, 1, 28),
                    Description = "A classic novel by Jane Austen.",
                    Pages = 279
                },
                new Book
                {
                    Name = "The Catcher in the Rye",
                    PublishingDate = new DateTime(1951, 7, 16),
                    Description = "A novel by J.D. Salinger.",
                    Pages = 224
                },
                new Book
                {
                    Name = "Harry Potter and the Philosopher's Stone",
                    PublishingDate = new DateTime(1997, 6, 26),
                    Description = "The first book in the Harry Potter series by J.K. Rowling.",
                    Pages = 309
                },
                new Book
                {
                    Name = "The Hobbit",
                    PublishingDate = new DateTime(1937, 9, 21),
                    Description = "A fantasy novel by J.R.R. Tolkien.",
                    Pages = 310
                },
                new Book
                {
                    Name = "The Da Vinci Code",
                    PublishingDate = new DateTime(2003, 3, 18),
                    Description = "A mystery-thriller novel by Dan Brown.",
                    Pages = 454
                },
                new Book
                {
                    Name = "The Lord of the Rings",
                    PublishingDate = new DateTime(1954, 7, 29),
                    Description = "A high-fantasy epic by J.R.R. Tolkien.",
                    Pages = 1178
                },
                new Book
                {
                    Name = "The Alchemist",
                    PublishingDate = new DateTime(1988, 8, 17),
                    Description = "A philosophical novel by Paulo Coelho.",
                    Pages = 163
                }
            );
        }
    }
}
