using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface IReviewRepository
	{
        public Task<List<Review>> GetAllAsync();
        public Task<Review?> GetByIdAsync(int id);
        public Task<List<Review>> GetBookReviews(int bookId);
        public Task<Review?> GetBookByReviewIdAsync(int id); 
        public Task<bool> CreateAsync(Review review);
        public Task<bool> UpdateAsync(int id, Review review);
        public Task<Review> DeleteAsync(int id);
        public Task<bool> Save(Review review);
        public Task<bool> ReviewerExists(int reviewrId);
    }
}

