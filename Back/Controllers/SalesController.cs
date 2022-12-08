using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CohorteApi.Data;
using CohorteApi.Models;
using Microsoft.AspNetCore.Identity;

namespace CohorteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _umanager;

        public SalesController(ApplicationDbContext context, UserManager<AppUser> umanager)
        {
            _context = context;
            _umanager = umanager;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await _context.Sales.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostSale(SaleObj sale)
        {
            var _user = await _umanager.FindByEmailAsync(sale.UserEmail);
            var _event = await _context.Events.Include(a => a.Category).Include(a => a.Sections).Include(a => a.Reviews).FirstAsync(a=>a.Id == sale.eventId);            
            Sale _sale = new()
            {
                CreatedAt = DateTime.Now,
                Event = _event,
                Price = sale.price,
                Qty = sale.qty,
                User = _user,
                Section = sale.section
            };
            _context.Sales.Add(_sale);
            await _context.SaveChangesAsync();
            return Ok(_sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        public class SaleObj
        {
            public string UserEmail { get; set; }
            public int eventId { get; set; }
            public int qty { get; set; }
            public string section { get; set; }
            public decimal price { get; set; }
        }
    }
}
