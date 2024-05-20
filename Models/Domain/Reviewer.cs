using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLibrary.Models.Domain
{
	public class Reviewer
	{
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "first name is required, please provide the first name.")]
        [MaxLength(100, ErrorMessage = "max length is 100 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "last name is required, please provide the last name.")]
        [MaxLength(100, ErrorMessage = "max length is 100 characters.")]
        public string LastName { get; set; }

        public List<Review> Reviews { get; set; }
    }
}

