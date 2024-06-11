using System;
namespace TheLibrary.Models.DTOs.Responses.Review
{
	public class DeleteReviewResponseDto
	{
        public int Id { get; set; }
        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int ReviewerId { get; set; }
        public int BookId { get; set; }
    }
}

