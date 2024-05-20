using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Models.Domain;
using TheLibrary.Repository.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Authors")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await authorRepository.GetAllAsync();

            return Ok(authors);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await authorRepository.GetByIdAsync(id);
            return Ok(author);
        }

        //get authors of a book
        [HttpGet]
        [Route("books/{bookId}")]
        public async Task<IActionResult> GetBookAuthorsByBookId(int bookId)
        {
            var authors = await authorRepository.GetAuthorsByBookIdAsync(bookId);
            return Ok(authors);
        }

        //get books of an author
        [HttpGet]
        [Route("{authorId}/books")]
        public async Task<IActionResult> GetBooksByAuthorId(int authorId)
        {
            var books = await authorRepository.GetBooksByAuthorIdAsycn(authorId);
            return Ok(books);
        }
    }
}

