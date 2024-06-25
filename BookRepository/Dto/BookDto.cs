using BookRepository.Models;
using System.ComponentModel.DataAnnotations;

namespace BookRepository.Dto
{
    public class BookDto
    {
        public int? Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public int? Year { get; set; }

        public string? Genre { get; set; }

        public string? Description { get; set; }

        public int? Pages { get; set; }

    }
}
