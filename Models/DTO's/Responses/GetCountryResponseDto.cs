using System;
using System.ComponentModel.DataAnnotations;
using TheLibrary.Models.Domain;

namespace TheLibrary.Models.DTOs.Responses
{
	public class GetCountryResponseDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
    }
}

