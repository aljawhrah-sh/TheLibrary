using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Repository.Interfaces;
using TheLibrary.Models.DTOs.Responses;
using TheLibrary.Models.DTOs.Requests.Book;
using TheLibrary.Models.Domain;
using TheLibrary.Data;
using TheLibrary.Models.DTOs.Responses.Book;
using TheLibrary.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Books")]
    public class BookController : Controller
    {

        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;
       

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await bookRepository.GetAllAsync();

            var booksDto = mapper.Map<List<BookDto>>(books);
            return Ok(booksDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if(book is null)
            {
                return NotFound();
            }

            var bookDto = mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        //Get book by ISBN
        [HttpGet("isbn/{ISBN}")]
        public async Task<IActionResult> GetByIsbn(string ISBN)
        {
            var book = await bookRepository.GetByIsbnAsync(ISBN);

            if (book is null)
            {
                return NotFound();
            }

            var bookDto = mapper.Map<GetBookResponseDto>(book);
            return Ok(bookDto);
        }

        //get book rating
        [HttpGet]
        [Route("{id}/rating")]
        public async Task<IActionResult> GetRatingById(int id)
        {
            var rating = await bookRepository.GetBookRatingAsync(id);
            
            if(rating is null)
            {
                return NotFound();
            }

            
            return Ok( new {rating});
        }

        //create
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]PostBookRequestDto bookRequestDto)
        {

            
            if (await bookRepository.IsNull(bookRequestDto.Title.ToUpper()))
            {
                return Conflict("Book already exists.");
            }
            var authorIds = bookRequestDto.BookAuthors;
            var categoryIds = bookRequestDto.BookCategories;
            
            
            var book = mapper.Map<Book>(bookRequestDto);

            try
            {
                var createdBook = await bookRepository.CreateAsync(book, authorIds, categoryIds);



                var bookDto = mapper.Map<PostBookResponseDto>(createdBook);
                return Ok(bookDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
           
        }
        //update
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id,[FromBody] PutBookRequestDto bookRequestDto)
        {
            var book = mapper.Map<Book>(bookRequestDto);

            if(!await bookRepository.UpdateAsync(id, book))
            {
                return NotFound();
            }

            book.Id = id;
            var bookDto = mapper.Map<PutBookResponseDto>(book);
            return Ok(bookDto);
        }

        //delete
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await bookRepository.DeleteAsync(id);

            if(book is null)
            {
                throw new Exception("the book does not already exist.");
            }

            var deletedBook = mapper.Map<DeleteBookResponseDto>(book);
            return Ok(deletedBook);
        }
    }

    
}

