using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs;
using TheLibrary.Repository.Interfaces;

namespace TheLibrary.Repository
{
	public class CategoryRepository : ICategoryRepository
	{

        //create db obj
        private readonly LibraryDbContext _context;

		public CategoryRepository(LibraryDbContext context)
		{
            _context = context;
		}

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<BookCategory?>> GetCategoriesByBookIdAsync(int bookId)
        {
            //i have the bookid now i need to return it's categories
           return await _context.BookCategories.Include(bc => bc.Category).Where(bc => bc.BookId == bookId).ToListAsync();
        }

        public async Task<List<BookCategory?>> GetBooksByCategoryIdAsync(int categoryId)
        {
            //select books of a sertain category 
            return await _context.BookCategories.Include(b => b.Book).Where(c => c.CategoryId == categoryId).ToListAsync();
        }

        public async Task<bool> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);

            return await Save(category);
        }

        public async Task<bool> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(existingCategory == null)
            {
                return false;
            }

            existingCategory.Name = category.Name;

            return await Save(category);
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(category == null)
            {
                return null;
            }

            _context.Remove(category);
             await Save(category);
            return category;
        }

        public async Task<bool> Save(Category category)
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsNull(string name)
        {
            return await _context.Categories.AnyAsync(n => n.Name.ToUpper() == name);
        }
    }
}

