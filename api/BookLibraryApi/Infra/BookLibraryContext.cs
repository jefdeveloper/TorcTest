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
                new Book { BookId = 1, Title = "The Da Vinci Code", FirstName = "Dan", LastName = "Brown", TotalCopies = 50, CopiesInUse = 40, Type = "Paperback", Isbn = "1234567898", Category = "Sci-Fi" },
                new Book { BookId = 2, Title = "The Grapes of Wrath", FirstName = "John", LastName = "Steinbeck", TotalCopies = 50, CopiesInUse = 35, Type = "Hardcover", Isbn = "1234567899", Category = "Fiction" },
                new Book { BookId = 3, Title = "The Hitchhiker's Guide to the Galaxy", FirstName = "Douglas", LastName = "Adams", TotalCopies = 50, CopiesInUse = 35, Type = "Paperback", Isbn = "1234567900", Category = "Non-Fiction" },
                new Book { BookId = 4, Title = "Moby-Dick", FirstName = "Herman", LastName = "Melville", TotalCopies = 30, CopiesInUse = 8, Type = "Hardcover", Isbn = "8901234567", Category = "Fiction" },
                new Book { BookId = 5, Title = "To Kill a Mockingbird", FirstName = "Harper", LastName = "Lee", TotalCopies = 20, CopiesInUse = 0, Type = "Paperback", Isbn = "9012345678", Category = "Non-Fiction" },
                new Book { BookId = 6, Title = "The Catcher in the Rye", FirstName = "J.D.", LastName = "Salinger", TotalCopies = 10, CopiesInUse = 1, Type = "Hardcover", Isbn = "0123456789", Category = "Non-Fiction" },
                new Book { BookId = 7, Title = "1984", FirstName = "George", LastName = "Orwell", TotalCopies = 40, CopiesInUse = 10, Type = "Paperback", Isbn = "9780451524935", Category = "Dystopian" },
                new Book { BookId = 8, Title = "Brave New World", FirstName = "Aldous", LastName = "Huxley", TotalCopies = 35, CopiesInUse = 5, Type = "Paperback", Isbn = "9780060850524", Category = "Dystopian" },
                new Book { BookId = 9, Title = "Fahrenheit 451", FirstName = "Ray", LastName = "Bradbury", TotalCopies = 25, CopiesInUse = 7, Type = "Paperback", Isbn = "9781451673319", Category = "Dystopian" },
                new Book { BookId = 10, Title = "Pride and Prejudice", FirstName = "Jane", LastName = "Austen", TotalCopies = 30, CopiesInUse = 12, Type = "Hardcover", Isbn = "9780141439518", Category = "Classic" },
                new Book { BookId = 11, Title = "War and Peace", FirstName = "Leo", LastName = "Tolstoy", TotalCopies = 15, CopiesInUse = 3, Type = "Hardcover", Isbn = "9780199232765", Category = "Classic" },
                new Book { BookId = 12, Title = "Crime and Punishment", FirstName = "Fyodor", LastName = "Dostoevsky", TotalCopies = 20, CopiesInUse = 6, Type = "Paperback", Isbn = "9780140449136", Category = "Classic" },
                new Book { BookId = 13, Title = "The Great Gatsby", FirstName = "F. Scott", LastName = "Fitzgerald", TotalCopies = 25, CopiesInUse = 9, Type = "Paperback", Isbn = "9780743273565", Category = "Classic" },
                new Book { BookId = 14, Title = "The Hobbit", FirstName = "J.R.R.", LastName = "Tolkien", TotalCopies = 40, CopiesInUse = 15, Type = "Hardcover", Isbn = "9780547928227", Category = "Fantasy" },
                new Book { BookId = 15, Title = "The Lord of the Rings", FirstName = "J.R.R.", LastName = "Tolkien", TotalCopies = 50, CopiesInUse = 20, Type = "Hardcover", Isbn = "9780618640157", Category = "Fantasy" },
                new Book { BookId = 16, Title = "Harry Potter and the Sorcerer's Stone", FirstName = "J.K.", LastName = "Rowling", TotalCopies = 60, CopiesInUse = 30, Type = "Paperback", Isbn = "9780590353427", Category = "Fantasy" },
                new Book { BookId = 17, Title = "Harry Potter and the Chamber of Secrets", FirstName = "J.K.", LastName = "Rowling", TotalCopies = 60, CopiesInUse = 28, Type = "Paperback", Isbn = "9780439064873", Category = "Fantasy" },
                new Book { BookId = 18, Title = "Harry Potter and the Prisoner of Azkaban", FirstName = "J.K.", LastName = "Rowling", TotalCopies = 60, CopiesInUse = 27, Type = "Paperback", Isbn = "9780439136365", Category = "Fantasy" },
                new Book { BookId = 19, Title = "The Alchemist", FirstName = "Paulo", LastName = "Coelho", TotalCopies = 35, CopiesInUse = 10, Type = "Paperback", Isbn = "9780061122415", Category = "Fiction" },
                new Book { BookId = 20, Title = "Don Quixote", FirstName = "Miguel", LastName = "de Cervantes", TotalCopies = 20, CopiesInUse = 4, Type = "Hardcover", Isbn = "9780060934347", Category = "Classic" },
                new Book { BookId = 21, Title = "The Odyssey", FirstName = "Homer", LastName = "", TotalCopies = 18, CopiesInUse = 2, Type = "Paperback", Isbn = "9780140268867", Category = "Epic" },
                new Book { BookId = 22, Title = "The Iliad", FirstName = "Homer", LastName = "", TotalCopies = 18, CopiesInUse = 2, Type = "Paperback", Isbn = "9780140275360", Category = "Epic" },
                new Book { BookId = 23, Title = "Dracula", FirstName = "Bram", LastName = "Stoker", TotalCopies = 22, CopiesInUse = 5, Type = "Paperback", Isbn = "9780141439846", Category = "Horror" },
                new Book { BookId = 24, Title = "Frankenstein", FirstName = "Mary", LastName = "Shelley", TotalCopies = 22, CopiesInUse = 5, Type = "Paperback", Isbn = "9780141439471", Category = "Horror" },
                new Book { BookId = 25, Title = "The Picture of Dorian Gray", FirstName = "Oscar", LastName = "Wilde", TotalCopies = 20, CopiesInUse = 4, Type = "Paperback", Isbn = "9780141439570", Category = "Classic" },
                new Book { BookId = 26, Title = "Jane Eyre", FirstName = "Charlotte", LastName = "Brontë", TotalCopies = 25, CopiesInUse = 7, Type = "Paperback", Isbn = "9780141441146", Category = "Classic" }
            );
        }
    }
}
