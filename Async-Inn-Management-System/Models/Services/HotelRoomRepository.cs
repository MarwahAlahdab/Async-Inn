using System;
using Async_Inn_Management_System.Data;
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



        public async Task<HotelRoom> AddHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }





        public async Task DeleteHotelRoom(int roomId, int hotelId)
        {

            HotelRoom hotel = await GetHotelRoom(hotelId, roomId);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();



        }



   
        public async Task<List<HotelRoom>> GetAllHotelRooms(int hotelId)
        {
            var hotels = await _context.HotelRooms.ToListAsync();
              return hotels;
        }




            public async Task<HotelRoom> GetHotelRoom(int roomId, int hotelId)
        {
            var hotelRoom = await _context.HotelRooms
                        .FirstOrDefaultAsync(hr => hr.RoomId == roomId && hr.HotelId == hotelId);

            return hotelRoom;
        }




        public async Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
    }
}

