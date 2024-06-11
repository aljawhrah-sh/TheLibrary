using System;
namespace TheLibrary.Models.DTOs.Responses.Review
{
    public class PostReviewResponseDto
    {
        public int Id { get; set; }
        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int ReviewerId { get; set; }
        //public ReviewerDto Reviewer { get; set; }
        public int BookId { get; set; }
    }
}

