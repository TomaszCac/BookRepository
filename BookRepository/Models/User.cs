using System.ComponentModel.DataAnnotations;

namespace BookRepository.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        public string Role { get; set; }

        public ICollection<Review> Reviews { get; set; }
        
    }
}
