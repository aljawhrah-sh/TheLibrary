using System;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
using TheLibrary.Repository.Interfaces;

namespace TheLibrary.Repository
{
	public class BookRepository : IBookRepository
	{
        //create db obj
        private readonly LibraryDbContext _context;

		public BookRepository(LibraryDbContext context)
		{
            _context = context;
		}

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book?> GetByIsbnAsync(string Isbn)
        {
            
           return  await _context.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author).FirstOrDefaultAsync(b => b.ISBN == Isbn);
        }

        public async Task<Book?> GetBookRatingAsync(int id)
        {
            return await _context.Books.Include(r => r.Reviews).ThenInclude(rv => rv.Reviewer).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBook == null)
            {
                return null;
            }

            existingBook.ISBN = book.ISBN;
            existingBook.Title = book.Title;
            existingBook.DatePublished = book.DatePublished;

            await _context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<Book> DeleteAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                return null;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

   
    }
}

