using System;
using System.ComponentModel.DataAnnotations;
using TheLibrary.Models.Domain;

namespace TheLibrary.Models.DTOs.Responses
{
	public class GetBookResponseDto
	{
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }

        //public List<ReviewDto> Reviews { get; set; }

       // public List<BookAuthorDto> BookAuthors { get; set; }

        //public List<BookCategoryDto> BookCategories { get; set; }
    }
}

