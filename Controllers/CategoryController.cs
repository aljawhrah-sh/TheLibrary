using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Repository.Interfaces;
using TheLibrary.Models.DTOs.Responses;
using TheLibrary.Models.DTOs.Requests.Category;
using TheLibrary.Models.DTOs;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs.Responses.Category;
using TheLibrary.Models.DTOs.Requests.Book;
using TheLibrary.Models.DTOs.Responses.Book;
using TheLibrary.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Categories")]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryRepository.GetAllAsync();
            var categoriesDto = mapper.Map<List<GetCategoryResponseDto>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);

            if(category is null)
            {
                return NotFound();
            }

            var categoryDto = mapper.Map<GetCategoryResponseDto>(category);
            return Ok(categoryDto);
        }

        //get all categories of a book
        [HttpGet]
        [Route("books/{bookId}")]
        public async Task<IActionResult> GetCategoriesByBookId(int bookId)
        {
            var categories = await categoryRepository.GetCategoriesByBookIdAsync(bookId);

            if(categories is null)
            {
                return NotFound();
            }

            var categoriesDto = mapper.Map<List<GetCategoryResponseDto>>(categories.Select(c => c.Category));
            return Ok(categoriesDto);
        }

        //get books of a category
        [HttpGet]
        [Route("{categoryId}/books")]
        public async Task<IActionResult> GetBooksByCategoryId(int categoryId)
        {
            var books = await categoryRepository.GetBooksByCategoryIdAsync(categoryId);

            if(books is null)
            {
                return NotFound();
            }

            var booksDto = mapper.Map<List<BookDto>>(books.Select(b => b.Book));
            return Ok(booksDto);
        }

        //create
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] PostCategoryRequestDto categoryRequestDto)
        {

            if(await categoryRepository.IsNull(categoryRequestDto.Name.ToUpper()))
            {
                return Conflict("Category already exists.");
            }

            //map from dto to domain
            var category = mapper.Map<Category>(categoryRequestDto);

            //send to repo
            await categoryRepository.CreateAsync(category);

            //map from domain to response dto
            var categoryDto = mapper.Map<PostCategoryResponseDto>(category);
            return Ok(categoryDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] PutCategoryRequestDto categoryRequestDto)
        {
            var category = mapper.Map<Category>(categoryRequestDto);

            if (await categoryRepository.UpdateAsync(id, category))
            {
                return NotFound();
            }

            category.Id = id;
            var categoryDto = mapper.Map<PutCategoryResponseDto>(category);
            return Ok(categoryDto);
        }

       
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await categoryRepository.DeleteAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            var deletedCategory = mapper.Map<DeleteCategoryResponseDto>(category);
            return Ok(deletedCategory);
        }
    }
}

