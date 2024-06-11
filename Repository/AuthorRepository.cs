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
            return await _context.Authors.Select(a => new Author
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Country = a.Country
            }).ToListAsync();
            
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            //author=>countryid=>country

            return await _context.Authors.Select(a => new Author { Id = a.Id, FirstName = a.FirstName, LastName = a.LastName, Country = a.Country })
                .FirstOrDefaultAsync(i => i.Id == id);

            
        }

        public async Task<List<BookAuthor?>> GetAuthorsByBookIdAsync(int bookId)
        {
            return await _context.BookAuthors.Include(a => a.Author).Where(i => i.BookId == bookId).ToListAsync();
        }

        public async Task<List<BookAuthor?>> GetBooksByAuthorIdAsycn(int authorId)
        {
            return await _context.BookAuthors.Include(b => b.Book).Where(i => i.AuthorId == authorId).ToListAsync();
        }

        public async Task<bool> CreateAsync(Author author)
        {
            await _context.Authors.AddAsync(author); 
            
            return await Save(author);
        }

        public async Task<bool> UpdateAsync(int id, Author author)
        {
            var existingAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if(existingAuthor == null)
            {
                return false;
            }

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.CountryId = author.CountryId;

            return await Save(author);
        }

        public async Task<Author> DeleteAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if(author == null)
            {
                return null;
            }

            _context.Authors.Remove(author);
             await Save(author);
            return author;
        }

        //save
        public async Task<bool>  Save(Author author)
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsNull(string firstName, string lastName)
        {
            if( await _context.Authors.AnyAsync(c => c.FirstName == firstName))
            {
                if (await _context.Authors.AnyAsync(l => l.LastName == lastName))
                {
                    return true;
                }

            }
            return false;
        }
    }
}

