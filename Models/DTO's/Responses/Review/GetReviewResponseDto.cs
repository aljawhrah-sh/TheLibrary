using System;
using System.ComponentModel.DataAnnotations;
using TheLibrary.Models.Domain;

namespace TheLibrary.Models.DTOs.Responses
{
	public class GetReviewResponseDto
	{
        public int Id { get; set; }
        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public ReviewerDto Reviewer { get; set; }
        public BookDto Book { get; set; }
        //public int BookId { get; set; }

    }
}

