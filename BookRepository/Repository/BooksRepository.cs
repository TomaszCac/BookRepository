using BookRepository.Data;
using BookRepository.Interfaces;
using BookRepository.Models;

namespace BookRepository.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _context;

        public BooksRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Id).ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByBookId(int id)
        {
            return _context.Reviews.Where(b => b.BookId == id).ToList();
        }

        public bool CreateBook(Book book)
        {
            book.Id = 0;
            _context.Add(book);
            return Save();
        }

        public bool UpdateBook(Book book)
        {
            _context.Update(book);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
