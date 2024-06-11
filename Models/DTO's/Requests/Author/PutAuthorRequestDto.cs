using System;
namespace TheLibrary.Models.DTOs.Requests
{
	public class PutAuthorRequestDto
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
    }
}

