using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {      
        public static async Task Run(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var provider = serviceScope.ServiceProvider;
            var context = provider.GetService<LibraryDbContext>();
            
            if (!context.Database.EnsureCreated() && await context.Books.AnyAsync())
            {
                return;
            }
            Seed(context);
            await context.SaveChangesAsync();
        }

        private static void Seed(LibraryDbContext context)
        {
            var books = new List<Book>
            {               
                new Book
                {
                    ID = 1,
                    Title = "To Kill a Mockingbird",
                    PublishingDate = new DateTime(1960, 7, 11),
                    Description = "A classic novel by Harper Lee.",
                    Pages = 281
                },
                new Book
                {
                    ID = 2,
                    Title = "1984",
                    PublishingDate = new DateTime(1949, 6, 8),
                    Description = "A dystopian novel by George Orwell.",
                    Pages = 328
                },
                new Book
                {
                    ID = 3,
                    Title = "The Great Gatsby",
                    PublishingDate = new DateTime(1925, 4, 10),
                    Description = "A novel by F. Scott Fitzgerald.",
                    Pages = 180
                },
                new Book
                {
                    ID = 4,
                    Title = "Pride and Prejudice",
                    PublishingDate = new DateTime(1813, 1, 28),
                    Description = "A classic novel by Jane Austen.",
                    Pages = 279
                },
                new Book
                {
                    ID = 5,
                    Title = "The Catcher in the Rye",
                    PublishingDate = new DateTime(1951, 7, 16),
                    Description = "A novel by J.D. Salinger.",
                    Pages = 224
                },
                new Book
                {
                    ID = 6,
                    Title = "Harry Potter and the Philosopher's Stone",
                    PublishingDate = new DateTime(1997, 6, 26),
                    Description = "The first book in the Harry Potter series by J.K. Rowling.",
                    Pages = 309
                },
                new Book
                {
                    ID = 7,
                    Title = "The Hobbit",
                    PublishingDate = new DateTime(1937, 9, 21),
                    Description = "A fantasy novel by J.R.R. Tolkien.",
                    Pages = 310
                },
                new Book
                {
                    ID = 8,
                    Title = "The Da Vinci Code",
                    PublishingDate = new DateTime(2003, 3, 18),
                    Description = "A mystery-thriller novel by Dan Brown.",
                    Pages = 454
                },
                new Book
                {
                    ID = 9,
                    Title = "The Lord of the Rings",
                    PublishingDate = new DateTime(1954, 7, 29),
                    Description = "A high-fantasy epic by J.R.R. Tolkien.",
                    Pages = 1178
                },
                new Book
                {
                    ID = 10,
                    Title = "The Alchemist",
                    PublishingDate = new DateTime(1988, 8, 17),
                    Description = "A philosophical novel by Paulo Coelho.",
                    Pages = 163
                }
            };

            context.Books.AddRange(books);
        }
    }
}
