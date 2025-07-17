namespace ConsoleApp5
{
    class Book
    {
        public string title;
        public string author;
        public int isbn;
        public bool isAvailable;

        public Book(string title, string author, int isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.isAvailable = true;
        }
    }
    class Library
    {
        List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void BorrowBook(string searchTitle)
        {
            foreach (var book in books)
            {
                if (book.title == searchTitle && book.isAvailable)
                {
                    book.isAvailable = false; // Mark the book as borrowed
                    Console.WriteLine($"Borrowed: {book.title} by {book.author}");
                    return;
                }
            }
            Console.WriteLine("Book not available or not found.");
        }
        public void ReturnBook(string returnTitle)
        {
            foreach (var book in books)
            {
                if (book.title == returnTitle && !book.isAvailable)
                {
                    book.isAvailable = true; // Mark the book as available
                    Console.WriteLine($"returned: {book.title} by {book.author}");
                    return;
                }
                else if (book.title != returnTitle)
                    Console.WriteLine("Book is not borrowed.");

            }



        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 9780));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 9781));
            library.AddBook(new Book("1984", "George Orwell", 9782));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("To Kill a Mockingbird"); // This book is not borrowed
        }
    }
}






