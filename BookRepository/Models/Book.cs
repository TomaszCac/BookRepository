using System.ComponentModel.DataAnnotations;

namespace BookRepository.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int Year { get; set; }

        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        public string Description { get; set; }

        [Required]
        public int Pages { get; set; }
    }
}
