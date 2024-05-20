using System;
using System.ComponentModel.DataAnnotations;

namespace TheLibrary.Models.Domain
{
	public class BookCategory
	{
        [Key]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

