using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface IReviewerRepository
	{
        public Task<List<Reviewer>> GetAllAsync();
        public Task<Reviewer?> GetByIdAsync(int id);
        public Task<Reviewer?> GetReviewsOfAReviewerAsync(int reviewerId);
        public Task<Review?> GetReviewerByReviewId(int reviewId);
        public Task<Reviewer> CreateAsync(Reviewer reviewer);
        public Task<Reviewer> UpdateAsync(int id, Reviewer reviewer);
        public Task<Reviewer> DeleteAsync(int id);
    }
}

