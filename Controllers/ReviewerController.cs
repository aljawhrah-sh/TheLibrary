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
    [Route("api/Reviewers")]
    public class ReviewerController : Controller
    {

        private readonly IReviewerRepository reviewerRepository;

        public ReviewerController(IReviewerRepository reviewerRepository)
        {
            this.reviewerRepository = reviewerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviewers = await reviewerRepository.GetAllAsync();
            return Ok(reviewers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reviewer = await reviewerRepository.GetByIdAsync(id);
            return Ok(reviewer);
        }

        //get all reviews by a reviewer
        //reviewer => reviews
        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> GetReviewsById(int id)
        {
            var reviews = await reviewerRepository.GetReviewsOfAReviewerAsync(id);
            return Ok(reviews);
        }

        //get reviewer of a review
        //review => reviewer
        [HttpGet]
        [Route("{id}/reviewer")]
        public async Task<IActionResult> GetReviewerByReviewId(int id)
        {
            var reviewer = await reviewerRepository.GetReviewerByReviewId(id);
            return Ok(reviewer);
        }
    }
}

