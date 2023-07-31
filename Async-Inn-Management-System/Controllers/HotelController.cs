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
using Async_Inn_Management_System.Models.Services;
using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelController(IHotel hotel)
        {
            _hotel = hotel;
        }


        // GET: api/Hotel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            var hotels = await _hotel.GetHoteles();

            if (hotels == null || hotels.Count == 0)
            {
                return NotFound();
            }
            return Ok(hotels);
        }



        // GET: api/Hotel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _hotel.GetHotel(id);
            if ( hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }



  










        // POST: api/Hotel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDTO>> PostHotel(HotelDTO hotelDTO)
        {
            var newHotel = await _hotel.Create(hotelDTO);

            return CreatedAtAction("GetHotel", new { id = newHotel.Id }, newHotel);
        }





        // DELETE: api/Hotel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_hotel.GetHotel(id) == null)
            {
                return NotFound();
            }

            await _hotel.Delete(id);

            return NoContent();
        }














        //private bool HotelExists(int id)
        //{

        //    return (_context.Hotels?.Any(e => e.ID == id)).GetValueOrDefault();
        //}




        // PUT: api/Hotel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        //{
        //    if (id != hotel.ID)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _hotel.UpdateHotel(id, hotel);
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        if (hotel == null)
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


    }







}
