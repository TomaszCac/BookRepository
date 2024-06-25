namespace BookRepository.Dto
{
    public class ReviewDto
    {
        public int? Id { get; set; }

        public int? UserId { get; set; }

        public int? BookId { get; set; }

        public string? Content { get; set; }

        public int? Rating { get; set; }

        public DateTime? ReviewDate { get; set; }
    }
}
