using AutoMapper;
using BookRepository.Dto;
using BookRepository.Models;
using System.Security.Cryptography;

namespace BookRepository.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ReviewDto, Review>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<UserDto, User>().ConvertUsing<UserDtoConverter>();
            CreateMap<User, UserDto>();
        }
        public class UserDtoConverter : ITypeConverter<UserDto, User>
        {
            public User Convert(UserDto source, User destination, ResolutionContext context)
            {
                User user = new User();
                using (var hmac = new HMACSHA256())
                {
                    user.PasswordSalt = hmac.Key;
                    user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(source.Password));
                }
                user.Username = source.Username;
                user.Email = source.Email;
                user.Role = "user";
                return user;
            }

        }
    }
}
