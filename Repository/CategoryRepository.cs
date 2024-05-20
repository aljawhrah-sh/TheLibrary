using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
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

        public async Task<BookCategory?> GetCategoriesByBookIdAsync(int bookId)
        {
            return await _context.BookCategories.Include(b => b.Book).Include(c => c.Category).FirstOrDefaultAsync(b => b.BookId == bookId);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<BookCategory?> GetBooksByCategoryIdAsync(int categoryId)
        {
            return await _context.BookCategories.Include(b => b.Book).Include(c => c.Category).FirstOrDefaultAsync(b => b.CategoryId == categoryId);
        }

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = category.Name;
            await _context.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(category == null)
            {
                return null;
            }

            _context.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        

        

        
    }
}

