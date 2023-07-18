using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly AsyncInnDbContext _context;

        public AmenityController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: api/Amenity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
          if (_context.Amenities == null)
          {
              return NotFound();
          }
            return await _context.Amenities.ToListAsync();
        }

        // GET: api/Amenity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
          if (_context.Amenities == null)
          {
              return NotFound();
          }
            var amenity = await _context.Amenities.FindAsync(id);

            if (amenity == null)
            {
                return NotFound();
            }

            return amenity;
        }

        // PUT: api/Amenity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.ID)
            {
                return BadRequest();
            }

            _context.Entry(amenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(id))
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

        // POST: api/Amenity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
          if (_context.Amenities == null)
          {
              return Problem("Entity set 'AsyncInnDbContext.Amenities'  is null.");
          }
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmenity", new { id = amenity.ID }, amenity);
        }

        // DELETE: api/Amenity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            if (_context.Amenities == null)
            {
                return NotFound();
            }
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }

            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmenityExists(int id)
        {
            return (_context.Amenities?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
