using BookApi.Models;

namespace BookApi.Services
{
    public class BookService
    {
        private List<Book> _books;

        public BookService()
        {
            _books = new List<Book>();
        }

        // Add a new book
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        // Get all books
        public List<Book> GetAll()
        {
            return _books;
        }

        // Get book by Id
        public Book? GetBookById(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        // Delete a book by Id
        public bool DeleteBook(int id)
        {
            var book = _books.Find(x => x.Id == id);
            if (book != null)
            {
                _books.Remove(book);
                return true;
            }
            return false;
        }

        // Update a book by Id
        public bool UpdateBook(int id, Book updatedBook)
        {
            var book = _books.Find(x => x.Id == id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Description = updatedBook.Description;
                return true;
            }
            return false;
        }
    }
}
