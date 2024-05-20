using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface IAuthorRepository
	{
		public Task<List<Author>> GetAllAsync();
		public Task<Author?> GetByIdAsync(int id);
		public Task<BookAuthor?> GetAuthorsByBookIdAsync(int bookId);
		public Task<BookAuthor?> GetBooksByAuthorIdAsycn(int authorId);
		public Task<Author> CreateAsync(Author author);
		public Task<Author> UpdateAsync(int id, Author author);
		public Task<Author> DeleteAsync(int id);
	}
}

