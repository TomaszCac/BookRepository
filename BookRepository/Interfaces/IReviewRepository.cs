using BookRepository.Models;

namespace BookRepository.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool Save();
        Review GetReview(int id);
        Book GetBookByReviewId(int id);
        User GetOwner(int id);
        ICollection<Review> GetReviewByRating(int ratingValue);

    }
}
