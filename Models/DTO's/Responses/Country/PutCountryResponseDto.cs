using System;
using System.ComponentModel.DataAnnotations;

namespace TheLibrary.Models.DTOs.Responses.Country
{
	public class PutCountryResponseDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

