using BookRepository.Models;

namespace BookRepository.Interfaces
{
    public interface IBooksRepository
    {
        ICollection<Book> GetBooks();
    }
}
