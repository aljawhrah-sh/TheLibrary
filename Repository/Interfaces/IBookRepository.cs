using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface IBookRepository
	{
        public Task<List<Book>> GetAllAsync();
        public Task<Book?> GetByIdAsync(int id);
        public Task<Book?> GetByIsbnAsync(string Isbn);
        public Task<Book?> GetBookRatingAsync(int id);
        public Task<Book> CreateAsync(Book book);
        public Task<Book> UpdateAsync(int id, Book book);
        public Task<Book> DeleteAsync(int id);
    }
}

