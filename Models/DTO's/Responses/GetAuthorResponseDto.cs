using System;
using System.ComponentModel.DataAnnotations;
using TheLibrary.Models.Domain;

namespace TheLibrary.Models.DTOs.Responses
{
	public class GetAuthorResponseDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }

    }
}

