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

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {


        private readonly IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }


        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var room = await _room.GetRooms();
            if (room == null || room.Count == 0)
            {
                return NotFound();
            }
            return room.ToList();
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

     

        // POST: api/Room
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            var createdRoom = await _room.Create(room);

            return CreatedAtAction("GetRoom", new { id = createdRoom.ID }, createdRoom);
        }

        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _room.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            await _room.Delete(id);

            return NoContent();
        }





        //private bool RoomExists(int id)
        //{
        //    return (_context.Rooms?.Any(e => e.ID == id)).GetValueOrDefault();
        //}



        // PUT: api/Room/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRoom(int id, Room room)
        //{
        //    if (id != room.ID)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _room.UpdateRoom(id, room);
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        if (room == null)
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
