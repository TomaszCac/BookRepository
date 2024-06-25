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
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
        
    }
}
