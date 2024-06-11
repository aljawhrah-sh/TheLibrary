using System;
using System.ComponentModel.DataAnnotations;
using TheLibrary.Models.Domain;

namespace TheLibrary.Models.DTOs
{
	public class ReviewDto
	{
        public int Id { get; set; }
        public string HeadLine { get; set; } 
        public string ReviewText { get; set; }
        public int Rating { get; set; }
       


    }
}

