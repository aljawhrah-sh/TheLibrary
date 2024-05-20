using System;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
using TheLibrary.Repository.Interfaces;

namespace TheLibrary.Repository
{
	public class AuthorRepository :IAuthorRepository
	{

        //create dbcontext obj
        private readonly LibraryDbContext _context;

		public AuthorRepository(LibraryDbContext context)
		{
            _context = context;
		}
        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.Include(a => a.Country).Include(a => a.BookAuthors).ThenInclude(ba => ba.Book).ToListAsync();
            
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            //author=>countryid=>country

            return await _context.Authors.Include(a => a.Country).FirstOrDefaultAsync(a => a.Id == id);

            
        }

        public async Task<BookAuthor?> GetAuthorsByBookIdAsync(int bookId)
        {
            return await _context.BookAuthors.Include(a => a.Author).FirstOrDefaultAsync(i => i.BookId == bookId);
        }

        public async Task<BookAuthor?> GetBooksByAuthorIdAsycn(int authorId)
        {
            return await _context.BookAuthors.Include(b => b.Book).FirstOrDefaultAsync(i => i.AuthorId == authorId);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(int id, Author author)
        {
            var existingAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if(existingAuthor == null)
            {
                return null;
            }

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.CountryId = author.CountryId;

            await _context.SaveChangesAsync();
            return existingAuthor;
        }

        public async Task<Author> DeleteAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if(author == null)
            {
                return null;
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return author;
        }


    }
}

