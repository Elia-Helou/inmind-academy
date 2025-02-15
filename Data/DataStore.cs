using Lab3.Domain.Entities;

namespace Lab3.Data
{
    public static class DataStore
    {
        public static List<Author> Authors { get; } = new List<Author>
        {
            new Author { AuthorId = 1, Name = "J.K. Rowling", BirthDate = new DateTime(1965, 07, 31), Country = "United Kingdom" },
            new Author { AuthorId = 2, Name = "George Orwell", BirthDate = new DateTime(1903, 06, 25), Country = "United Kingdom" },
            new Author { AuthorId = 3, Name = "Mark Twain", BirthDate = new DateTime(1835, 11, 30), Country = "United States" },
            new Author { AuthorId = 4, Name = "Jane Austen", BirthDate = new DateTime(1775, 12, 16), Country = "United Kingdom" },
            new Author { AuthorId = 5, Name = "Haruki Murakami", BirthDate = new DateTime(1949, 01, 12), Country = "Japan" }
        };

        public static List<Book> Books { get; } = new List<Book>
        {
            new Book { BookId = 1, Title = "Harry Potter and the Sorcerers Stone", AuthorId = 1, PublishedYear = 1997, Isbn = "9780747532743" },
            new Book { BookId = 2, Title = "1984", AuthorId = 2, PublishedYear = 1949, Isbn = "9780451524935" },
            new Book { BookId = 3, Title = "Animal Farm", AuthorId = 2, PublishedYear = 1945, Isbn = "9780451526342" },
            new Book { BookId = 4, Title = "The Adventures of Tom Sawyer", AuthorId = 3, PublishedYear = 1876, Isbn = "9780486400778" },
            new Book { BookId = 5, Title = "Norwegian Wood", AuthorId = 5, PublishedYear = 1987, Isbn = "9780375704024" }
        };
    }
}
