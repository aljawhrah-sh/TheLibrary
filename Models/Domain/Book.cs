using System;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLibrary.Models.Domain
{
	public class Book
	{
        internal DateTime DatePublished;

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "ISBN is required, please provide the ISBN.")]
        [MaxLength(10, ErrorMessage = "max length is 10 characters.")]
        [MinLength(3, ErrorMessage = "min length is 3 characters.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "title is required, please provide the title.")]
        [MaxLength(200, ErrorMessage = "max clength is 200 characters.")]
        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public List<Review> Reviews { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }

        public List<BookCategory> BookCategories { get; set; }

    }
}

