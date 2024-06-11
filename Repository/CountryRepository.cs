using System;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs.Requests;
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
            return await _context.Countries.Include(a => a.Authors).ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries.Include(a => a.Authors).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Country?> GetAuthorsByCountryId(int countryId)
        {

            return await _context.Countries.Include(a => a.Authors).FirstOrDefaultAsync(i => i.Id == countryId);
        }

        public async Task<Author?> GetCountryByAuthorId(int authorId)
        {
            return await _context.Authors.Select(a => new Author
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Country = a.Country
            }).FirstOrDefaultAsync(i => i.Id == authorId);
        }

        public async Task<bool> CreateAsync(Country country)
        {
            
            await _context.Countries.AddAsync(country);
            return await Save(country);
        }
        public async Task<bool> UpdateAsync(int id, Country country)
        {
            var existingCountry = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if(existingCountry == null)
            {
                return false;
            }
            
            existingCountry.Name = country.Name;

            return await Save(country);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            
            var country = await _context.Countries.Include(a => a.Authors).FirstOrDefaultAsync(x => x.Id == id);
            
            //if(country != null && country.Authors == null)
            //{
            //_context.Countries.Remove(country);
            //await Save(country);
            //return true;    
            //}else if(country.Authors != null)
            //{
            //    return false;
            //}

            //return false;

            //check if country exist 
            if (!await IsNull(country.Name))
            {
                throw new Exception("the country does not exist");
            }

            foreach(var author in country.Authors)
            {
                if(country.Authors != null)
                {
                    return false;
                }
            }
            

            _context.Countries.Remove(country);
            return await Save(country);
        }

        public async Task<bool> Save(Country country)
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsNull(string country)
        {
            return await _context.Countries.AnyAsync(c => c.Name.ToUpper() == country);
        }
        
    }
}

