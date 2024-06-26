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
        [HttpPost("register")]
        public IActionResult Register(UserDto user)
        {
            return Ok(_userRepository.CreateUser(_mapper.Map<User>(user)));
        }
        [HttpPost("login")]
        public IActionResult Login(UserDto user)
        {
            if (!_userRepository.VerifyEmail(user.Email))
            {
                ModelState.AddModelError("", "User not found");
                return BadRequest(ModelState);
            }
            if (!_userRepository.VerifyPassword(user))
            {
                ModelState.AddModelError("", "Wrong password");
                return BadRequest(ModelState);
            }
            return Ok(_userRepository.CreateToken(user));
                
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto user)
        {
            return Ok(_userRepository.CreateUser(_mapper.Map<User>(user)));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_userRepository.DeleteUser(id));
        }
    }
}
