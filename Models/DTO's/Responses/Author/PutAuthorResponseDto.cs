﻿using System;
namespace TheLibrary.Models.DTOs.Responses
{
	public class PutAuthorResponseDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
    }
}

