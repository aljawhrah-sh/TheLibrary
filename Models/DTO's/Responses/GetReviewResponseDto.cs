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
        public Reviewer Reviewer { get; set; }
        public Book Book { get; set; }
    }
}

