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
        public Task<bool> CreateAsync(Reviewer reviewer);
        public Task<bool> UpdateAsync(int id, Reviewer reviewer);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> Save(Reviewer reviewer);
        public Task<bool> IsNull(Reviewer reviewer);
    }
}

