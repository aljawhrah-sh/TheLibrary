using System;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
using TheLibrary.Repository.Interfaces;

namespace TheLibrary.Repository
{
	public class ReviewerRepository : IReviewerRepository
	{

        //create db obj
        private readonly LibraryDbContext _context;

		public ReviewerRepository(LibraryDbContext context)
		{
            _context = context;
		}
        public async Task<List<Reviewer>> GetAllAsync()
        {
            return await _context.Reviewers.ToListAsync();
        }

        public async Task<Reviewer?> GetByIdAsync(int id)
        {
            return await _context.Reviewers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Reviewer?> GetReviewsOfAReviewerAsync(int reviewerId)
        {
            return await _context.Reviewers.Include(rv => rv.Reviews).FirstOrDefaultAsync(i => i.Id == reviewerId);
        }

        public async Task<Review?> GetReviewerByReviewId(int reviewId)
        {
            return await _context.Reviews.Include(r => r.Reviewer).FirstOrDefaultAsync(i => i.Id == reviewId);
        }

        public async Task<bool> CreateAsync(Reviewer reviewer)
        {
            await _context.Reviewers.AddAsync(reviewer);

            return await Save(reviewer);
        }

        public async Task<bool> UpdateAsync(int id, Reviewer reviewer)
        {
            var existingReviewer = await _context.Reviewers.FirstOrDefaultAsync(x => x.Id == id);

            if(existingReviewer == null)
            {
                return false;
            }

            existingReviewer.FirstName = reviewer.FirstName;
            existingReviewer.LastName = reviewer.LastName;

            return await Save(reviewer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reviewer = await _context.Reviewers.FirstOrDefaultAsync(x => x.Id == id);

            if(reviewer == null)
            {
                return false;
            }

            _context.Reviewers.Remove(reviewer);

            return await Save(reviewer);
        }

        public async Task<bool> Save(Reviewer reviewer)
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsNull(Reviewer reviewer)
        {
            if(await _context.Reviews.AnyAsync(r => r.ReviewerId == reviewer.Id))
            {
                return true;
            }
            return false;
        }
    }
}

