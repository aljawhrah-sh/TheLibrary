using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface IReviewRepository
	{
        public Task<List<Review>> GetAllAsync();
        public Task<Review?> GetByIdAsync(int id);
        public Task<Book?> GetBookReviews(int bookId);
        public Task<Review?> GetBookByReviewIdAsync(int id); 
        public Task<Review> CreateAsync(Review review);
        public Task<Review> UpdateAsync(int id, Review review);
        public Task<Review> DeleteAsync(int id);
    }
}

