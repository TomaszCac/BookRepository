using BookRepository.Models;

namespace BookRepository.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
        ICollection<Review> GetUserReviews(int id);

    }
}
