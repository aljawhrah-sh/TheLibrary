using System;
using System.ComponentModel.DataAnnotations;
using TheLibrary.Models.Domain;

namespace TheLibrary.Models.DTOs
{
	public class ReviewerDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

