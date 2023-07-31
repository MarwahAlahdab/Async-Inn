using System;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {

        private readonly AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }



        public async Task<HotelRoomDTO> AddHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            


            var hotelRoom = new HotelRoom
            {
                HotelId = hotelRoomDTO.HotelId,
                RoomId = hotelRoomDTO.RoomId,
                State = hotelRoomDTO.State
                // Set other properties accordingly
            };

            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelRoomDTO;

        }



   
        public async Task<List<HotelRoomDTO>> GetAllHotelRooms(int hotelId)
        {
          

            var hotelRooms = await _context.HotelRooms.Where(hr => hr.HotelId == hotelId).ToListAsync();

            var hotelRoomDTOs = hotelRooms.Select(hr => new HotelRoomDTO
            {
                HotelId = hr.HotelId,
                RoomId = hr.RoomId,
                State = hr.State
                // Map other properties accordingly
            }).ToList();

            return hotelRoomDTOs;
        }




            public async Task<HotelRoomDTO> GetHotelRoom(int roomId, int hotelId)
        {
            var hotelRoom = await _context.HotelRooms
                        .FirstOrDefaultAsync(hr => hr.RoomId == roomId && hr.HotelId == hotelId);
            if (hotelRoom == null)
            {
                return null; 
            }

            var hotelRoomDTO = new HotelRoomDTO
            {
                HotelId = hotelRoom.HotelId,
                RoomId = hotelRoom.RoomId,
                State= hotelRoom.State
            };

            return hotelRoomDTO;
        }







        public async Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }



        public async Task DeleteHotelRoom(int roomId, int hotelId)
        {

            HotelRoom hotel = await _context.HotelRooms.FindAsync(hotelId, roomId);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();



        }




    }
}

