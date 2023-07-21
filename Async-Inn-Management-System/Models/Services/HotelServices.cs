using System;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Services
{
	public class HotelServices : IHotel
	{
        private readonly AsyncInnDbContext _context;

        public HotelServices(AsyncInnDbContext context)
        {
            _context = context;
        }


        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;

        }

     

        public async Task<Hotel> GetHotel(int hotelId)
        {
            Hotel hotel = await _context.Hotels.FindAsync(hotelId);
            return hotel;
            
        }

        public async Task<List<Hotel>> GetHoteles()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> UpdateHotel(int hotelId, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task Delete(int hotelId)
        {
            Hotel hotel = await GetHotel(hotelId);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }








    }
}

