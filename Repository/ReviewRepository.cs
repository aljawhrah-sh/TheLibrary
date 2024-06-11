using System;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
using TheLibrary.Repository.Interfaces;

namespace TheLibrary.Repository
{
	public class ReviewRepository : IReviewRepository
	{

        //create db obj
        private readonly LibraryDbContext _context;

		public ReviewRepository(LibraryDbContext context)
		{
            _context = context;
		}

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews.Include(rv => rv.Reviewer).Include(b => b.Book).ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.Include(rv => rv.Reviewer).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Review>> GetBookReviews(int bookId)
        {

            return await _context.Reviews.Where(review => review.BookId == bookId).ToListAsync();

        }

        public async Task<Review?> GetBookByReviewIdAsync(int id)
        {
            return await _context.Reviews.Include(b => b.Book).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> CreateAsync(Review review)
        {
            
            await _context.Reviews.AddAsync(review);

            return await Save(review);
        }

        public async Task<bool> UpdateAsync(int id, Review review)
        {
            var existingReview = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if(existingReview == null)
            {
                return false;
            }

            existingReview.HeadLine = review.HeadLine;
            existingReview.ReviewText = review.ReviewText;
            existingReview.Rating = review.Rating;

            return await Save(review);
        }

        public async Task<Review> DeleteAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if(review == null)
            {
                return null;
            }

            _context.Reviews.Remove(review);
             await Save(review);
            return review;
        }

        public async Task<bool> Save(Review review)
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ReviewerExists(int reviewerId)
        {
            return await _context.Reviewers.AnyAsync(i => i.Id == reviewerId);
        }
    }
}

