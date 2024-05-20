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
    [Route("api/Categories")]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            return Ok(category);
        }

        //get all categories of a book
        [HttpGet]
        [Route("books/{bookId}")]
        public async Task<IActionResult> GetCategoriesByBookId(int bookId)
        {
            var categories = await categoryRepository.GetCategoriesByBookIdAsync(bookId);
            return Ok(categories);
        }

        //get books of a category
        [HttpGet]
        [Route("{categoryId}/books")]
        public async Task<IActionResult> GetBooksByCategoryId(int categoryId)
        {
            var books = await categoryRepository.GetBooksByCategoryIdAsync(categoryId);
            return Ok(books);
        }
    }
}

