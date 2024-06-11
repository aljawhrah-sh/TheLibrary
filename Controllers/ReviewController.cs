using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheLibrary.Repository.Interfaces;
using TheLibrary.Models.DTOs.Responses;
using AutoMapper;
using TheLibrary.Models.DTOs;
using TheLibrary.Models.DTOs.Requests.Review;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs.Responses.Review;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheLibrary.Controllers
{
    [ApiController]
    [Route("api/Reviews")]
    public class ReviewController : Controller
    {

        private readonly IReviewRepository reviewRepository;
        private readonly IMapper mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await reviewRepository.GetAllAsync();
            var reviewsDto = mapper.Map<List<GetReviewResponseDto>>(reviews);
            return Ok(reviewsDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await reviewRepository.GetByIdAsync(id);

            if(review is null)
            {
                return NotFound();
            }

            var reviewDto = mapper.Map<GetReviewResponseDto>(review);
            return Ok(reviewDto);
        }

        //get book reviews
        [HttpGet]
        [Route("books/{id}")]
        public async Task<IActionResult> GetBookReviews(int id)
        {
            var reviews = await reviewRepository.GetBookReviews(id);

            if(reviews is null)
            {
                return NotFound();
            }

            var reviewsDto = mapper.Map<List<ReviewDto>>(reviews);
            return Ok(reviewsDto);
        }

        //get book from a review
        [HttpGet]
        [Route("{id}/book")]
        public async Task<IActionResult> GetBookByReview(int id)
        {
            var book = await reviewRepository.GetBookByReviewIdAsync(id);

            if(book is null)
            {
                return NotFound();
            }

            var bookDto = mapper.Map<BookDto>(book.Book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(PostReviewRequestDto reviewRequestDto)
        {

            if(await reviewRepository.ReviewerExists(reviewRequestDto.ReviewerId))
            {
                var review = mapper.Map<Review>(reviewRequestDto);
                await reviewRepository.CreateAsync(review);
                var reviewDto = mapper.Map<PostReviewResponseDto>(review);
                return Ok(reviewDto);
            }

            return Conflict("reviewer does not exist.");
           
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateReview([FromRoute]int id,[FromBody]PutReviewRequestDto reviewRequestDto)
        {
            var review = mapper.Map<Review>(reviewRequestDto);

            if(!await reviewRepository.UpdateAsync(id, review))
            {
                return NotFound();
            }

            review.Id = id;
            var reviewDto = mapper.Map<PutReviewResponseDto>(review);
            return Ok(reviewDto);
        }

        [HttpDelete]
        //[Route("{id:int}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await reviewRepository.DeleteAsync(id);

            if(review is null)
            {
                return NotFound();
            }

            var reviewDto = mapper.Map<DeleteReviewResponseDto>(review);
            return Ok(reviewDto);
        }
    }
}

