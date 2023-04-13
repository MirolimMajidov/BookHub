using BookHub.Models;

namespace BookHub.DataProvider
{
    public static class DataSeeder
    {
        public static void DemoData(this BookContext context, ILogger logger)
        {
            try
            {
                if (!context.Books.Any())
                {
                    var categories = new List<Category>()
                        {
                            new Category { Id = Guid.NewGuid(), Name = "Fiction" },
                            new Category { Id = Guid.NewGuid(), Name = "Science Fiction" },
                            new Category { Id = Guid.NewGuid(), Name = "Non-Fiction" },
                            new Category { Id = Guid.NewGuid(), Name = "Biography" }
                        };
                    context.Categories.AddRange(categories);

                    var books = new List<Book>()
                        {
                            new Book
                            {
                                Id = Guid.NewGuid(),
                                Title = "To Kill a Mockingbird",
                                Author = "Harper Lee",
                                Price = 10.99m,
                                CategoryId = categories[0].Id,
                                Description = "A novel set in the Depression-era South that explores themes of racism and injustice."
                            },
                            new Book
                            {
                                Id = Guid.NewGuid(),
                                Title = "1984",
                                Author = "George Orwell",
                                Price = 8.99m,
                                CategoryId = categories[1].Id,
                                Description = "A dystopian novel set in a totalitarian society in the year 1984."
                            },
                            new Book
                            {
                                Id = Guid.NewGuid(),
                                Title = "The Selfish Gene",
                                Author = "Richard Dawkins",
                                Price = 14.99m,
                                CategoryId = categories[2].Id,
                                Description = "A book on evolutionary biology that introduces the concept of the gene as the unit of natural selection."
                            },
                            new Book
                            {
                                Id = Guid.NewGuid(),
                                Title = "Steve Jobs",
                                Author = "Walter Isaacson",
                                Price = 12.99m,
                                CategoryId = categories[3].Id,
                                Description = "A biography of Steve Jobs, co-founder of Apple Inc., based on over 40 interviews with Jobs and others."
                            }
                    };

                    context.Books.AddRange(books);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception error while entering demo data: {Message}", ex.Message);
            }
        }
    }
}
