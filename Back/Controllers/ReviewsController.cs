using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CohorteApi.Data;
using CohorteApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CohorteApi.Core.Models.Events;

namespace CohorteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ReviewsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        /// <summary>
        /// Get all reviews 
        /// </summary>
        /// <returns></returns>
        // GET: api/Reviews
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
        {
            return await _context.Review.ToListAsync();
        }

        // GET: api/Reviews
        [HttpGet("MyReviews")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Review>>> MyReviews(int eventId)
        {
            var user = await GetUserFromContext();
            if (eventId > 0)
            {
                return await _context.Review.Where(x => x.UserId == user.Id && x.EventId == eventId).ToListAsync();
            }
            return await _context.Review.Where(x => x.UserId == user.Id).ToListAsync();
        }


        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Review.FindAsync(id);

            if (review == null || review.IsDeleted || review.IsBanned || !review.IsShowed)
            {
                return NotFound();
            }
            
            //TODO Map to dto
            return review;
        }


        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(ReviewPostModel review)
        {
            var @event = await _context.Events.FindAsync(review.EventId);
            if(@event == null) return NotFound("Event not found");
            if (@event.EventTime > DateTime.UtcNow) return BadRequest("The event hasn't started yet");
           

            var user = await GetUserFromContext();
            if (user == null) return NotFound("user is invalid");

            //TODO check if user has buyed a ticket
            //  if(! user.tickets.Any( x => x.Event == review.EventId)) return BadRequest("You didnt assisted to this event");


            var newReview = new Review()
            {
                UserId = user.Id,
                EventId = @event.Id,
                Comment = review.Comment,
                TimeStamp = DateTime.UtcNow,
                IsShowed = true,
                UserName = user.UserName,
            };

            _context.Review.Add(newReview);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

            return CreatedAtAction("GetReview", new { id = newReview.Id }, review);
        }

        /// <summary>
        /// Only owner or admin can delete a comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Reviews/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review == null) return NotFound();
            //check if is admin
            //check if i own the comment
            var user = await GetUserFromContext();
            if (review.UserId == user.Id) //i'm the owner
            {
                _context.Review.Remove(review);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                //i'm an admin
                var role = this.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                if (role.ToUpper() == "ADMIN")
                {
                    _context.Review.Remove(review);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }
            return Unauthorized();
        }

        private async Task<bool> ReviewExists(int id)
        {
            return  await _context.Review.AnyAsync(e => e.Id == id);
        }

        private async Task<AppUser> GetUserFromContext()
        {
            var userEmail = this.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var user = await _userManager.FindByEmailAsync(userEmail);
            return user;

        }
    }
}
