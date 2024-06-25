using AutoMapper;
using BookRepository.Dto;
using BookRepository.Interfaces;
using BookRepository.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<ICollection<ReviewDto>>(_reviewRepository.GetReviews()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<ReviewDto>(_reviewRepository.GetReview(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReviewDto review)
        {
            return Ok(_reviewRepository.CreateReview(_mapper.Map<Review>(review)));
        }

        [HttpPut]
        public IActionResult Put([FromBody] ReviewDto review)
        {
            return Ok(_reviewRepository.UpdateReview(_mapper.Map<Review>(review)));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ReviewDto review)
        {
            return Ok(_reviewRepository.DeleteReview(_mapper.Map<Review>(review)));
        }
    }
}
