using AutoMapper;
using BookRepository.Dto;
using BookRepository.Interfaces;
using BookRepository.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<ICollection<BookDto>>(_booksRepository.GetBooks()));
        }
        [HttpGet("reviews/{bookId}")]
        public IActionResult GetReviewsByBookId(int bookId)
        {
            return Ok(_mapper.Map<ICollection<ReviewDto>>(_booksRepository.GetReviewsByBookId(bookId)));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<BookDto>(_booksRepository.GetBook(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDto book)
        {
            return Ok(_booksRepository.CreateBook(_mapper.Map<Book>(book)));
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookDto book)
        {
            return Ok(_booksRepository.UpdateBook(_mapper.Map<Book>(book)));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] BookDto book)
        {
            return Ok(_booksRepository.DeleteBook(_mapper.Map<Book>(book)));
        }
    }
}
