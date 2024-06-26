using BookRepository.Data;
using BookRepository.Dto;
using BookRepository.Interfaces;
using BookRepository.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BookRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
            var userEntity = _context.Users.Where(b => b.Email == user.Email).FirstOrDefault();
            using (var hmac = new HMACSHA512(userEntity.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(user.Password));
                return computedHash.SequenceEqual(userEntity.PasswordHash);
            }
        }

        public bool VerifyEmail(string email)
        {
            if (_context.Users.Any(b => b.Email == email))
                return true;
            else
                return false;
        }

        public string CreateToken(UserDto user)
        {
            var userEntity = _context.Users.Where(b => b.Email == user.Email).FirstOrDefault();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userEntity.Username),
                new Claim(ClaimTypes.Role, userEntity.Role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                ) ;
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
