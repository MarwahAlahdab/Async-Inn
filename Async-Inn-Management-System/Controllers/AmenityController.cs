using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.Interfaces;

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenityController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            var amenity = await _amenity.GetAmenities();

            if (amenity == null || amenity.Count == 0)
            {
                return NotFound();
            }
            return amenity.ToList();
        }

        // GET: api/Amenity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            if (await _amenity.GetAmenity(id) == null)
            {
                return NotFound();
            }


            return await _amenity.GetAmenity(id);
        }








        // POST: api/Amenity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            if (amenity == null)
            {
                return Problem("Entity set 'AsyncInnDbContext.Amenities'  is null.");
            }
            var newAmenity = await _amenity.Create(amenity);

            return CreatedAtAction("GetAmenity", new { id = newAmenity.ID }, newAmenity);



        }









        // DELETE: api/Amenity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {

            if (_amenity.GetAmenity(id) == null)
            {
                return NotFound();
            }

            await _amenity.Delete(id);
            return NoContent();
        }


        // PUT: api/Amenity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        //public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        //{
        //    if (id != amenity.ID)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _amenity.UpdateAmenity(id, amenity);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (amenity == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}






        //private bool AmenityExists(int id)
        //{
        //    return (_context.Amenities?.Any(e => e.ID == id)).GetValueOrDefault();
        //}





    } 
}
