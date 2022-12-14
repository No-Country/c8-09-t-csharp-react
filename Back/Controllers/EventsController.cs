using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CohorteApi.Data;
using CohorteApi.Models;

namespace CohorteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents([FromQuery] int categoryId)
        {
            if (categoryId > 0)
            {
                var eventsFromCat = await _context.Events
                    .Include(i => i.Reviews)
                    .Include(i => i.Category)
                    .Include(i => i.Sections)
                    .Where(x => x.CategoryId == categoryId).ToListAsync();

                return eventsFromCat;
            }
            var previousResults = await _context.Events
                .Include(i => i.Reviews)
                .Include(i => i.Category)                    
                .Include(i => i.Sections)
                .ToListAsync();
            return previousResults;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events
                .Include(i => i.Reviews)
                .Include(i => i.Category)
                .Include(i => i.Sections)
                .FirstAsync(a=>a.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event _event)
        {
            _context.Events.Add(_event);
            await _context.SaveChangesAsync();
            return Ok(_event);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.Events
                .Include(i => i.Reviews)
                .Include(i => i.Category)
                .Include(i => i.Sections)
                .FirstAsync(a => a.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }

        [HttpGet("{id}/details")]
        public async Task<string> EventDetail(int id)
        {
            return await Task.FromResult("not implemented yet");
        }

        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsAdmin()
        {
            return await _context.Events.Include(a => a.Category).Include(a => a.Sections).Include(a => a.Reviews).ToListAsync();
        }
        [HttpGet("TopEvents")]
        public async Task<ActionResult<IEnumerable<Event>>> GetTopEvents()
        {
            var Events = await _context.Events.Include(a => a.Category).Include(a => a.Sections).Include(a => a.Reviews).ToListAsync();
            var _sales = await _context.Sales.Include(a=>a.Event).ToListAsync();
            var SalesGrouped = _sales.GroupBy(a => a.Event);
            var TopEvents = SalesGrouped.OrderByDescending(a => a.Count()).Take(5).Select(a=>a.Key);
            return TopEvents.ToList();
        }
    }
}
