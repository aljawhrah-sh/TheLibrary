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

        public async Task<Reviewer> CreateAsync(Reviewer reviewer)
        {
            await _context.Reviewers.AddAsync(reviewer);
            await _context.SaveChangesAsync();
            return reviewer;
        }

        public async Task<Reviewer> UpdateAsync(int id, Reviewer reviewer)
        {
            var existingReviewer = await _context.Reviewers.FirstOrDefaultAsync(x => x.Id == id);

            if(existingReviewer == null)
            {
                return null;
            }

            existingReviewer.FirstName = reviewer.FirstName;
            existingReviewer.LastName = reviewer.LastName;

            await _context.SaveChangesAsync();
            return existingReviewer;
        }

        public async Task<Reviewer> DeleteAsync(int id)
        {
            var reviewer = await _context.Reviewers.FirstOrDefaultAsync(x => x.Id == id);

            if(reviewer == null)
            {
                return null;
            }

            _context.Reviewers.Remove(reviewer);
            await _context.SaveChangesAsync();
            return reviewer;
        }

        
        

        
    }
}

