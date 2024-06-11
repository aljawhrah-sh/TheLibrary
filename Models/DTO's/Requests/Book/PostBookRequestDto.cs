using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Models.DTOs.Requests.Book
{
	public class PostBookRequestDto
	{

        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
       
        public List<int> BookAuthors { get; set; }
        public List<int> BookCategories { get; set; }
    }
}

