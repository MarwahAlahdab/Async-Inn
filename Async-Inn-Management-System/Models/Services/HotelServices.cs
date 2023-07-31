using System;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
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


        public async Task<HotelDTO> Create(HotelDTO hotelDTO)
        {
            var hotel = new Hotel
            {
                Name = hotelDTO.Name,
                StreetAddress = hotelDTO.StreetAddress,
                Phone = hotelDTO.Phone
            };

            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();

            hotelDTO.Id = hotel.ID;
            hotelDTO.Rooms = new List<HotelRoomDTO>();

            return hotelDTO;



        }

     

        public async Task<HotelDTO> GetHotel(int hotelId)
        {
            var hotel = await _context.Hotels
           .Include(h => h.HotelRooms)
           .ThenInclude(hr => hr.Room)
           .ThenInclude(r => r.RoomAmenities)
           .ThenInclude(ra => ra.Amenity) 
           .FirstOrDefaultAsync(h => h.ID == hotelId);

            if (hotel == null)
                return null;

            var hotelDTO = new HotelDTO
            {
                Id = hotel.ID,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                Phone = hotel.Phone,
                Rooms = hotel.HotelRooms.Select(hr => new HotelRoomDTO
                {
                    HotelId = hr.HotelId,
                    RoomId = hr.RoomId,
                    State = hr.State,
                    Room = new RoomDTO
                    {
                        Id = hr.Room.ID,
                        Name = hr.Room.Name,
                        NickName = hr.Room.NickName,
                        Price = hr.Room.Price,
                        PetFriendly = hr.Room.PetFriendly,
                        Layout = hr.Room.Layout,
                        Amenities = hr.Room.RoomAmenities.Select(ra => new AmenityDTO
                        {
                            ID = ra.Amenity.ID,
                            Name = ra.Amenity.Name
                        }).ToList()
                    }
                }).ToList()
            };

            return hotelDTO;





        }

        public async Task<List<HotelDTO>> GetHoteles()
        {
           
            var hotels = await _context.Hotels
           .Include(h => h.HotelRooms)
           .ThenInclude(hr => hr.Room)
           .ToListAsync();

            List<HotelDTO> hotelDTOs = new List<HotelDTO>();

            foreach (var hotel in hotels)
            {
                HotelDTO hotelDTO = new HotelDTO
                {
                    Id = hotel.ID,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    Phone = hotel.Phone
             
                };

                hotelDTO.Rooms = hotel.HotelRooms.Select(hr => new HotelRoomDTO
                {
                    HotelId = hr.HotelId,
                    RoomId = hr.RoomId,
                    Room = new RoomDTO
                    {
                        Id = hr.Room.ID,
                        Name = hr.Room.Name,
                    }
                }).ToList();

                hotelDTOs.Add(hotelDTO);
            }

            return hotelDTOs;
        }







        public async Task<Hotel> UpdateHotel(int hotelId, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task Delete(int hotelId)
        {
            Hotel hotel = await _context.Hotels.FindAsync(hotelId); 
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }




    }
}

