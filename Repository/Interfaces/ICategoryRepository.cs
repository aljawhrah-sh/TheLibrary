using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface ICategoryRepository
	{
        public Task<List<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int id);
        public Task<BookCategory?> GetCategoriesByBookIdAsync(int bookId);
        public Task<BookCategory?> GetBooksByCategoryIdAsync(int categoryId);
        public Task<Category> CreateAsync(Category category);
        public Task<Category> UpdateAsync(int id, Category category);
        public Task<Category> DeleteAsync(int id);
    }
}

