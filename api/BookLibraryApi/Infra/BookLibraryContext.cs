using BookLibraryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Infra
{
    public class BookLibraryContext(DbContextOptions<BookLibraryContext> options) : DbContext(options)
    {
        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "The Da Vinci Code",
                    FirstName = "Dan",
                    LastName = "Brown",
                    TotalCopies = 50,
                    CopiesInUse = 40,
                    Type = "Paperback",
                    Isbn = "1234567898",
                    Category = "Sci-Fi"
                },
                new Book
                {
                    BookId = 2,
                    Title = "The Grapes of Wrath",
                    FirstName = "John",
                    LastName = "Steinbeck",
                    TotalCopies = 50,
                    CopiesInUse = 35,
                    Type = "Hardcover",
                    Isbn = "1234567899",
                    Category = "Fiction"
                },
                new Book
                {
                    BookId = 3,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    FirstName = "Douglas",
                    LastName = "Adams",
                    TotalCopies = 50,
                    CopiesInUse = 35,
                    Type = "Paperback",
                    Isbn = "1234567900",
                    Category = "Non-Fiction"
                },
                new Book
                {
                    BookId = 4,
                    Title = "Moby-Dick",
                    FirstName = "Herman",
                    LastName = "Melville",
                    TotalCopies = 30,
                    CopiesInUse = 8,
                    Type = "Hardcover",
                    Isbn = "8901234567",
                    Category = "Fiction"
                },
                new Book
                {
                    BookId = 5,
                    Title = "To Kill a Mockingbird",
                    FirstName = "Harper",
                    LastName = "Lee",
                    TotalCopies = 20,
                    CopiesInUse = 0,
                    Type = "Paperback",
                    Isbn = "9012345678",
                    Category = "Non-Fiction"
                },
                new Book
                {
                    BookId = 6,
                    Title = "The Catcher in the Rye",
                    FirstName = "J.D.",
                    LastName = "Salinger",
                    TotalCopies = 10,
                    CopiesInUse = 1,
                    Type = "Hardcover",
                    Isbn = "0123456789",
                    Category = "Non-Fiction"
                }
            );
        }
    }
}
