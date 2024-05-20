using System;
using TheLibrary.Models.Domain;

namespace TheLibrary.Repository.Interfaces
{
	public interface ICountryRepository
	{
        public Task<List<Country>> GetAllAsync();
        public Task<Country?> GetByIdAsync(int id);
        public Task<Author?> GetCountryByAuthorId(int authorId);
        public Task<Country?> GetAuthorsByCountryId(int countryId);
        public Task<Country> CreateAsync(Country country);
        public Task<Country> UpdateAsync(int id, Country country);
        public Task<Country> DeleteAsync(int id);
    }
}

