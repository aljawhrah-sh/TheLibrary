using System;
using System.ComponentModel.DataAnnotations;

namespace TheLibrary.Models.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
    }
}

