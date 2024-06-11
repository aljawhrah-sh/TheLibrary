using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs.Responses;
using TheLibrary.Repository.Interfaces;
using TheLibrary.Models.DTOs.Requests;
using TheLibrary.Data;
using TheLibrary.Models.DTOs;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Authors")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;
        

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await authorRepository.GetAllAsync();

            //map from domain to dto
            var authorsDto = mapper.Map<List<GetAuthorResponseDto>>(authors);
            
            return Ok(authorsDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await authorRepository.GetByIdAsync(id);

            if(author is null)
            {
                return NotFound();
            }

            //map from domain to dto
            var authorDto = mapper.Map<GetAuthorResponseDto>(author);
            return Ok(authorDto);
        }

        //get authors of a book
        [HttpGet]
        [Route("books/{bookId}")]
        public async Task<IActionResult> GetBookAuthorsByBookId(int bookId)
        {
            var authors = await authorRepository.GetAuthorsByBookIdAsync(bookId);

            if(authors is null)
            {
                return NotFound();
            }

            //map from domain to dto
            var authorsDto = mapper.Map<List<AuthorDto>>(authors.Select(a => a.Author));
            return Ok(authorsDto);
        }

        //get books of an author
        [HttpGet]
        [Route("{authorId}/books")]
        public async Task<IActionResult> GetBooksByAuthorId(int authorId)
        {
            var books = await authorRepository.GetBooksByAuthorIdAsycn(authorId);

            if(books is null)
            {
                return NotFound();
            }

            var booksDto = mapper.Map<List<BookDto>>(books.Select(b => b.Book));
            return Ok(booksDto);
        }

        //create
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody]PostAuthorRequestDto authorRequestDto)
        {

            if(await authorRepository.IsNull(authorRequestDto.FirstName.ToUpper(), authorRequestDto.LastName.ToUpper()))
                {
                    return Conflict(new { message = "Author already exists." });
                }

            //map from dto to domain
            var author = mapper.Map<Author>(authorRequestDto);

            //create the other using the repo
            await authorRepository.CreateAsync(author);
            

            //map from domain to dto
            var authorResponseDto = mapper.Map<PostAuthorResponseDto>(author);
            return Ok(authorResponseDto);
        }

        //update
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAuthor([FromRoute] int id, [FromBody] PutAuthorRequestDto authorRequestDto)
        {
            var author = mapper.Map<Author>(authorRequestDto);

            if(!await authorRepository.UpdateAsync(id, author))
            {
                return NotFound();
            }

            author.Id = id;
            var authorResponseDto = mapper.Map<PutAuthorResponseDto>(author);
            return Ok(authorResponseDto);
        }

        //delete
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
           var author = await authorRepository.DeleteAsync(id);

            if(author is null)
            {
                return NotFound();
            }

            var deletedAuthor = mapper.Map<DeleteAuthorResponseDto>(author);
            return Ok(deletedAuthor);
        }
    }
}

