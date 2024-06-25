using BookRepository.Data;
using BookRepository.Interfaces;
using BookRepository.Models;

namespace BookRepository.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(b => b.Id).ToList();
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book GetBookByReviewId(int id)
        {
            return _context.Reviews.Where(b => b.Id == id).Select(b => b.Book).FirstOrDefault();
        }

        public User GetOwner(int id)
        {
            return _context.Reviews.Where(b => b.Id == id).Select(b => b.User).FirstOrDefault();
        }

        public ICollection<Review> GetReviewByRating(int ratingValue)
        {
            return _context.Reviews.Where(b => b.Rating == ratingValue).ToList();
        }

        public bool CreateReview(Review review)
        {
           // review.User = _context.Users.Where(b => b.Id == review.UserId).FirstOrDefault();
           // review.Book = _context.Books.Where(b => b.Id == review.BookId).FirstOrDefault();
            _context.Add(review);
            return Save();
        }

        public bool UpdateReview(Review review)
        {
            review.User = _context.Users.Where(b => b.Id == review.UserId).FirstOrDefault();
            review.Book = _context.Books.Where(b => b.Id == review.BookId).FirstOrDefault();
            _context.Update(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            review.User = _context.Users.Where(b => b.Id == review.UserId).FirstOrDefault();
            review.Book = _context.Books.Where(b => b.Id == review.BookId).FirstOrDefault();
            _context.Remove(review);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
