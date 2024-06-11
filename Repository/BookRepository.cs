using System;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs;
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
            return await _context.Books.Include(r => r.Reviews).ThenInclude(rv => rv.Reviewer)
                .Include(a => a.BookAuthors).ThenInclude(au => au.Author)
                .Include(c => c.BookCategories).ThenInclude(ca => ca.Category).ToListAsync();
        
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Book?> GetByIsbnAsync(string Isbn)
        {
            
           return  await _context.Books.FirstOrDefaultAsync(b => b.ISBN == Isbn);
        }

        public async Task<double?> GetBookRatingAsync(int id)
        {
            var avg = await _context.Reviews.Where(b => b.BookId == id).AverageAsync(r => (double)r.Rating);
            
            return avg;


        }

        public async Task<Book?> CreateAsync(Book book, List<int> authors, List<int> categories)
        {
            //check if author does exist
            foreach(var authorId in authors)
            {
                if(! await AuthorExists(authorId))
                {
                    throw new Exception("Author does not exist!");
                }
            }
            //check if category does exist
            foreach(var categoryId in categories)
            {
                if(! await CategoryExists(categoryId))
                {
                    throw new Exception("category does not exist!");
                }
            }

            await _context.Books.AddAsync(book);
            await Save(book);

            //add them to BookAuthor & bookCategory
            foreach (var authorId in authors)
            {
                BookAuthor bookAuthor = new BookAuthor
                {
                     BookId = book.Id,
                    AuthorId = authorId
                };
                await _context.BookAuthors.AddAsync(bookAuthor);
                
            }

            foreach(var categoryId in categories)
            {
                BookCategory bookCategory = new BookCategory
                {
                    BookId = book.Id,
                    CategoryId = categoryId
                };
                await _context.BookCategories.AddAsync(bookCategory);
               
            }
 
            await _context.SaveChangesAsync();

            //return including author and category
            return await _context.Books
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Include(b => b.BookCategories).ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(b => b.Id == book.Id);

        }

        public async Task<bool> UpdateAsync(int id, Book book)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBook == null)
            {

                return false;
            }

            existingBook.ISBN = book.ISBN;
            existingBook.Title = book.Title;
            existingBook.DatePublished = book.DatePublished;

            return await Save(book);
        }

        public async Task<Book> DeleteAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                return null;
            }

            _context.Books.Remove(book);
            await Save(book);
            return book;
        }

        public async Task<bool> Save(Book book)
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsNull(string title)
        {
            return await _context.Books.AnyAsync(t => t.Title == title);
        }

        public async Task<bool> AuthorExists(int authorId)
        {
            return await _context.Authors.AnyAsync(i => i.Id == authorId);
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await _context.Categories.AnyAsync(i => i.Id == categoryId);
        }
    }
}

