using System;
namespace TheLibrary.Models.DTOs.Responses.Review
{
	public class PutReviewResponseDto
	{
        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; }
    }
}

