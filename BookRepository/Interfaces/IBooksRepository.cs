using BookRepository.Models;

namespace BookRepository.Interfaces
{
    public interface IBooksRepository
    {
        ICollection<Book> GetBooks();
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();
        Book GetBook(int id);
        ICollection<Review> GetReviewsByBookId(int id);
    }
}
