using System;
namespace TheLibrary.Models.DTOs.Requests.Book
{
	public class PutBookRequestDto
	{

        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

