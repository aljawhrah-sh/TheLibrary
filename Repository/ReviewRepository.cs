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
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book?> GetBookReviews(int bookId)
        {
            return await _context.Books.Include(r => r.Reviews).ThenInclude(rev => rev.Reviewer).FirstOrDefaultAsync(i => i.Id == bookId);
        }

        public async Task<Review?> GetBookByReviewIdAsync(int id)
        {
            return await _context.Reviews.Include(b => b.Book).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Review> CreateAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> UpdateAsync(int id, Review review)
        {
            var existingReview = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if(existingReview == null)
            {
                return null;
            }

            existingReview.HeadLine = review.HeadLine;
            existingReview.ReviewText = review.ReviewText;
            existingReview.Rating = review.Rating;

            await _context.SaveChangesAsync();
            return existingReview;
        }

        public async Task<Review> DeleteAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if(review == null)
            {
                return null;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }
        
    }
}

