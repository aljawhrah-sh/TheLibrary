using System;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
using TheLibrary.Repository.Interfaces;

namespace TheLibrary.Repository
{
	public class CountryRepository : ICountryRepository
	{

        //create db obj
        private readonly LibraryDbContext _context;

		public CountryRepository(LibraryDbContext context)
		{
            _context = context;
		}

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Country?> GetAuthorsByCountryId(int countryId)
        {
            return await _context.Countries.Include(a => a.Authors).FirstOrDefaultAsync(i => i.Id == countryId);
        }

        public async Task<Author?> GetCountryByAuthorId(int authorId)
        {
            return await _context.Authors.Include(c => c.Country).FirstOrDefaultAsync(i => i.Id == authorId);
        }

        public async Task<Country> CreateAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return country;
        }
        public async Task<Country> UpdateAsync(int id, Country country)
        {
            var existingCountry = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if(existingCountry == null)
            {
                return null;
            }

            existingCountry.Name = country.Name;
            await _context.SaveChangesAsync();

            return existingCountry;
        }

        public async Task<Country> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if(country == null)
            {
                return null;
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }


        

        
    }
}

