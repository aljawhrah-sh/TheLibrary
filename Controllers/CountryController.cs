using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Repository.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Countries")]
    public class CountryController : Controller
    {

        private readonly ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await countryRepository.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await countryRepository.GetByIdAsync(id);
            return Ok(country);
        }

        //get country of an author
        [HttpGet]
        [Route("authors/{id}")]
        public async Task<IActionResult> GetAuthorCountry(int id)
        {
            var country = await countryRepository.GetCountryByAuthorId(id);
            return Ok(country);
        }

        //get authors of a country
        [HttpGet]
        [Route("{id}/authors")]
        public async Task<IActionResult> GetAuthorsOfACountry(int id)
        {
            var authors = await countryRepository.GetAuthorsByCountryId(id);
            return Ok(authors);
        }
    }
}

