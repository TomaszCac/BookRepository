using System.ComponentModel.DataAnnotations;

namespace BookRepository.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BookId {  get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
