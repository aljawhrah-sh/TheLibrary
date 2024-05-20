using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLibrary.Models.Domain
{
	public class Category
	{
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "category name is required, please provide a category name.")]
        [MaxLength(50, ErrorMessage = "max length is 50 characters.")]
        public string Name { get; set; }

        public List<BookCategory> BookCategories { get; set; }
    }
}

