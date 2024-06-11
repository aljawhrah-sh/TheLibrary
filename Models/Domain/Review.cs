using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLibrary.Models.Domain
{
	public class Review
	{
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "review headline is required, please provide a headline.")]
        [MinLength(10, ErrorMessage = "min length is 10 characters.")]
        [MaxLength(200, ErrorMessage = "max length is 200 characters.")]
        public string HeadLine { get; set; }

        [Required(ErrorMessage = "review text is required, please provide a review text.")]
        [MinLength(50, ErrorMessage = "min length is 50 characters.")]
        [MaxLength(2000, ErrorMessage = "max length is 2000 characters.")]
        public string ReviewText { get; set; }

        [Range(1, 5, ErrorMessage = "rating should be between 1 to 5.")]
        public int Rating { get; set; }

        public Reviewer Reviewer { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }

        public int ReviewerId { get; set; }
    }
}

