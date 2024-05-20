using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLibrary.Models.Domain
{
	public class Country
	{
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "country name is required, please provide a name.")]
        [MaxLength(50, ErrorMessage = "max length is 50 characters.")]
        public string Name { get; set; }

        public List<Author> Authors { get; set; }
    }
}

