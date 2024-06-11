using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface IBookRepository
	{
        public Task<List<Book>> GetAllAsync();
        public Task<Book?> GetByIdAsync(int id);
        public Task<Book?> GetByIsbnAsync(string Isbn);
        public Task<double?> GetBookRatingAsync(int id);
        public Task<Book?> CreateAsync(Book book, List<int> authors, List<int> categories);
        public Task<bool> UpdateAsync(int id, Book book);
        public Task<Book> DeleteAsync(int id);
        public Task<bool> Save(Book book);
        public Task<bool> IsNull(string title);
        public Task<bool> AuthorExists(int authorId);
        public Task<bool> CategoryExists(int categoryId);
    }
}

