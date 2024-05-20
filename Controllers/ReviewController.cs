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
    [Route("api/Reviews")]
    public class ReviewController : Controller
    {

        private readonly IReviewRepository reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await reviewRepository.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await reviewRepository.GetByIdAsync(id);
            return Ok(review);
        }

        //get book reviews
        [HttpGet]
        [Route("books/{id}")]
        public async Task<IActionResult> GetBookReviews(int id)
        {
            var reviews = await reviewRepository.GetBookReviews(id);
            return Ok(reviews);
        }

        //get book from a review
        [HttpGet]
        [Route("{id}/book")]
        public async Task<IActionResult> GetBookByReview(int id)
        {
            var book = await reviewRepository.GetBookByReviewIdAsync(id);
            return Ok(book);
        }
    }
}

