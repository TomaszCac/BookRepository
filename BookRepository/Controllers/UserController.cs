using AutoMapper;
using BookRepository.Dto;
using BookRepository.Interfaces;
using BookRepository.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<ICollection<UserDto>>(_userRepository.GetUsers()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<UserDto>(_userRepository.GetUser(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto user)
        {
            return Ok(_userRepository.CreateUser(_mapper.Map<User>(user)));
        }

        [HttpPut]
        public IActionResult Put([FromBody] UserDto user)
        {
            return Ok(_userRepository.UpdateUser(_mapper.Map<User>(user)));
        }

        [HttpDelete]
        public IActionResult Delete(UserDto user)
        {
            return Ok(_userRepository.DeleteUser(_mapper.Map<User>(user)));
        }
    }
}
