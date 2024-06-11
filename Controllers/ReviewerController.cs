using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Repository.Interfaces;
using TheLibrary.Models.DTOs.Responses;
using AutoMapper;
using TheLibrary.Models.DTOs;
using TheLibrary.Models.DTOs.Requests.Reviewer;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs.Responses.Reviewer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Reviewers")]
    public class ReviewerController : Controller
    {

        private readonly IReviewerRepository reviewerRepository;
        private readonly IMapper mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            this.reviewerRepository = reviewerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviewers = await reviewerRepository.GetAllAsync();

            if(reviewers is null)
            {
                return NotFound();
            }

            var reviewersDto = mapper.Map<List<GetReviewerResponseDto>>(reviewers);
            return Ok(reviewersDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reviewer = await reviewerRepository.GetByIdAsync(id);

            if(reviewer is null)
            {
                return NotFound();
            }

            var reviewerDto = mapper.Map<GetReviewerResponseDto>(reviewer);
            return Ok(reviewerDto);
        }

        //get all reviews by a reviewer
        //reviewer => reviews
        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> GetReviewsById(int id)
        {
            var reviews = await reviewerRepository.GetReviewsOfAReviewerAsync(id);

            if(reviews is null)
            {
                return NotFound();
            }

            var reviewsDto = mapper.Map<List<ReviewDto>>(reviews.Reviews);
            return Ok(reviewsDto);
        }

        //get reviewer of a review
        //review => reviewer
        [HttpGet]
        [Route("{id}/reviewer")]
        public async Task<IActionResult> GetReviewerByReviewId(int id)
        {
            var reviewer = await reviewerRepository.GetReviewerByReviewId(id);

            if(reviewer is null)
            {
                return NotFound();
            }

            var reviewerDto = mapper.Map<ReviewerDto>(reviewer.Reviewer);
            return Ok(reviewerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReviewer([FromBody] PostReviewerRequestDto reviewerRequestDto)
        {
            var reviewer = mapper.Map<Reviewer>(reviewerRequestDto);

            await reviewerRepository.CreateAsync(reviewer);
            var reviewerDto = mapper.Map<PostReviewerResponseDto>(reviewer);
            return Ok(reviewerDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateReviewer([FromRoute] int id, [FromBody] PutReviewerRequestDto reviewerRequestDto)
        {
            var reviewer = mapper.Map<Reviewer>(reviewerRequestDto);

            if(!await reviewerRepository.UpdateAsync(id, reviewer))
            {
                return NotFound();
            }

            reviewer.Id = id;
            var reviewerDto = mapper.Map<PutReviewerResponseDto>(reviewer);
            return Ok(reviewerDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReviewer(int id)
        {
            var reviewer = await reviewerRepository.GetByIdAsync(id);
            if (reviewer is null)
            {
                return NotFound();
                
            }
            await reviewerRepository.DeleteAsync(id);
            var reviewerDto = mapper.Map<DeleteReviewerResponseDto>(reviewer);
            return Ok(reviewerDto);
        }
    }
}

