using System;
namespace TheLibrary.Models.DTOs.Requests.Review
{
    public class PostReviewRequestDto
    {

        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        //public ReviewerDto Reviewer { get; set; }
       // public BookDto Book { get; set; }
        public int BookId { get; set; }
        public int ReviewerId { get; set; }
    }
}

