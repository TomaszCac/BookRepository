using BookRepository.Dto;
using BookRepository.Models;

namespace BookRepository.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        string CreateToken(UserDto user);
        bool CreateUser(User user);
        bool UpdateUsername(string username, int id);
        bool UpdatePassword(string password, int id);
        bool VerifyEmail(string email);
        bool VerifyPassword(UserDto user);
        bool DeleteUser(int id);
        bool Save();

    }
}
