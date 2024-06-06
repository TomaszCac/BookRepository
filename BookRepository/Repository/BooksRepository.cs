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
    }
}
