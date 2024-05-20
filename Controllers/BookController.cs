using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Repository.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Books")]
    public class BookController : Controller
    {

        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            return Ok(book);
        }

        //Get book by ISBN
        [HttpGet("isbn/{ISBN}")]
        public async Task<IActionResult> GetByIsbn(string ISBN)
        {
            var book = await bookRepository.GetByIsbnAsync(ISBN);
            return Ok(book);
        }

        //get book rating
        [HttpGet]
        [Route("{id}/rating")]
        public async Task<IActionResult> GetRatingById(int id)
        {
            var book = await bookRepository.GetBookRatingAsync(id);
            return Ok(book);
        }
    }
}

