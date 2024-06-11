using System;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs.Requests;

namespace TheLibrary.Repository.Interfaces
{
	public interface ICountryRepository
	{
        public Task<List<Country>> GetAllAsync();
        public Task<Country?> GetByIdAsync(int id);
        public Task<Author?> GetCountryByAuthorId(int authorId);
        public Task<Country?> GetAuthorsByCountryId(int countryId);
        public Task<bool> CreateAsync(Country country);
        public Task<bool> UpdateAsync(int id, Country country);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> Save(Country country);
        public Task<bool> IsNull (string country);
    }
}

