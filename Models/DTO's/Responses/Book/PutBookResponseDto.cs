using System;
namespace TheLibrary.Models.DTOs.Responses.Book
{
	public class PutBookResponseDto
	{
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

