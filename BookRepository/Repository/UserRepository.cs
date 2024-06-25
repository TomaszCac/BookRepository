using BookRepository.Data;
using BookRepository.Dto;
using BookRepository.Interfaces;
using BookRepository.Models;
using System.Security.Cryptography;

namespace BookRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool DeleteUser(int id)
        {
            _context.Users.Remove(_context.Users.Where(b => b.Id == id).FirstOrDefault());
            return Save();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(b => b.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(b => b.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePassword(string password, int id)
        {
            var user = _context.Users.Where(b => b.Id == id).FirstOrDefault();
            using (var hmac = new HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            _context.Update(user);
            return Save();
        }

        public bool UpdateUsername(string username, int id)
        {
            var user = _context.Users.Where(b => b.Id == id).FirstOrDefault();
            user.Username = username;
            _context.Update(user);
            return Save();
        }

        public bool VerifyPassword(UserDto user)
        {
            using (var hmac = new HMACSHA512(_context.Users.Where(b => b.Email == user.Email).FirstOrDefault().PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(user.Password));
                return computedHash.SequenceEqual(_context.Users.Where(b => b.Email == user.Email).FirstOrDefault().PasswordHash);
            }
        }

        public bool VerifyEmail(string email)
        {
            if (_context.Users.Any(b => b.Email == email))
                return true;
            else
                return false;
        }
    }
}
