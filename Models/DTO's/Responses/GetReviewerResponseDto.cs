using System;
using System.ComponentModel.DataAnnotations;
using TheLibrary.Models.Domain;

namespace TheLibrary.Models.DTOs.Responses
{
	public class GetReviewerResponseDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Reviewer> Reviews { get; set; }
    }
}

