    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Repository.Interfaces;
using TheLibrary.Models.DTOs.Responses;
using AutoMapper;
using TheLibrary.Models.DTOs.Requests;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs.Responses.Country;
using Microsoft.EntityFrameworkCore;
using TheLibrary.Data;
using TheLibrary.Models.DTOs.Requests.Country;
using TheLibrary.Models.DTOs;
using TheLibrary.Models.DTOs.Requests.Book;
using TheLibrary.Models.DTOs.Responses.Book;
using TheLibrary.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Countries")]
    public class CountryController : Controller
    {

        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;
       

        public CountryController(ICountryRepository countryRepository, IMapper mapper )
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await countryRepository.GetAllAsync();
            var countriesDto = mapper.Map<List<GetCountryResponseDto>>(countries);
            return Ok(countriesDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await countryRepository.GetByIdAsync(id);

            if(country is null)
            {
                return NotFound();
            }

            var countryDto = mapper.Map<GetCountryResponseDto>(country);
            return Ok(countryDto);
        }

        //get country of an author
        [HttpGet]
        [Route("authors/{id}")]
        public async Task<IActionResult> GetAuthorCountry(int id)
        {
            var country = await countryRepository.GetCountryByAuthorId(id);

            if(country is null)
            {
                return NotFound();
            }

            var countryDto = mapper.Map<GetCountryResponseDto>(country.Country);
            return Ok(countryDto);
        }

        //get authors of a country
        [HttpGet]
        [Route("{id}/authors")]
        public async Task<IActionResult> GetAuthorsOfACountry(int id)
        {
            var country = await countryRepository.GetAuthorsByCountryId(id);

            if(country is null)
            {
                return NotFound();
            }

            var authorsDto = mapper.Map<List<AuthorDto>>(country.Authors);
            return Ok(authorsDto);
        }

        
        
        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody]PostCountryRequestDto countryRequestDto)
        {

            if(await countryRepository.IsNull(countryRequestDto.Name.ToUpper()))
                {
                    return Conflict(new { message = "Country already exists." });
                }

            var country = mapper.Map<Country>(countryRequestDto);
            await countryRepository.CreateAsync(country);

            //map from domain to response dto
            var countryDto = mapper.Map<PostCountryResponseDto>(country);
            return Ok(countryDto);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCountry([FromRoute]int id,[FromBody] PutCountryRequestDto countryRequestDto)
        {

            var country = mapper.Map<Country>(countryRequestDto);

            if(!await countryRepository.UpdateAsync(id, country))
            {
                
                return NotFound();
            }
                country.Id = id;
                var countryDto = mapper.Map<PostCountryResponseDto>(country);

                return Ok(countryDto);   
            
            
        }


        //if a country contains an author it cannot be deleted
        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int id)
        {

           
            if (!await countryRepository.DeleteAsync(id))
            {
                return NotFound(new {message = "Country with Id {0} has authors, it cannot be deleted.", id});
            }
              
            
            return Ok(id);
        }

        
    }
}

