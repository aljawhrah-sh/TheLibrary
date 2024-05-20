using System;
using System.ComponentModel.DataAnnotations;

namespace TheLibrary.Models.Domain
{
	public class BookAuthor
	{
        [Key]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}

