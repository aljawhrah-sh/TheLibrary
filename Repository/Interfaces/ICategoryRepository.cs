using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface ICategoryRepository
	{
        public Task<List<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int id);
        public Task<List<BookCategory?>> GetCategoriesByBookIdAsync(int bookId);
        public Task<List<BookCategory?>> GetBooksByCategoryIdAsync(int categoryId);
        public Task<bool> CreateAsync(Category category);
        public Task<bool> UpdateAsync(int id, Category category);
        public Task<Category> DeleteAsync(int id);
        public Task<bool> Save(Category category);
        public Task<bool> IsNull(string name);
    }
}

