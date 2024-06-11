using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using TheLibrary.Models.DTOs;

namespace TheLibrary.Models.Domain
{
	public class Author
	{
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "the first name is required, please provide the first name.")]
        [MaxLength(100, ErrorMessage = "max length is 100 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "the last name is required, please provide the last name.")]
        [MaxLength(100, ErrorMessage = "max length is 100 characters.")]
        public string LastName { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
        
    }
}

