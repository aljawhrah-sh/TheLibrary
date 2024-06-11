using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface IAuthorRepository
	{
		public Task<List<Author>> GetAllAsync();
		public Task<Author?> GetByIdAsync(int id);
		public Task<List<BookAuthor?>> GetAuthorsByBookIdAsync(int bookId);
		public Task<List<BookAuthor?>> GetBooksByAuthorIdAsycn(int authorId);
		public Task<bool> CreateAsync(Author author);
		public Task<bool> UpdateAsync(int id, Author author);
		public Task<Author> DeleteAsync(int id);
		public Task<bool> Save(Author author);
		public Task<bool> IsNull(string firstName, string lastName);
	}
}

