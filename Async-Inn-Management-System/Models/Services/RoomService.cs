using System;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Services
{
	public class RoomService : IRoom
	{
        private readonly AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<RoomDTO> Create(RoomDTO roomDTO)
        {
            var room = new Room
            {
                Name = roomDTO.Name,
                NickName = roomDTO.NickName,
                Price = roomDTO.Price,
                PetFriendly = roomDTO.PetFriendly
            };

            _context.Entry(room).State = EntityState.Added;

            await _context.SaveChangesAsync();


            RoomDTO addedAmenity = await GetRoom(room.ID);

            return addedAmenity;
        }

       

        public async Task<RoomDTO> GetRoom(int roomId)
        {
            Room room = await _context.Rooms.FindAsync(roomId);

            if (room == null)
            {
                return null;
            }

            var roomDTO = new RoomDTO
            {
                Id = room.ID,
                Name = room.Name,
                NickName = room.NickName,
                Price = room.Price,
                PetFriendly = room.PetFriendly
            };

            return roomDTO;
        }






        public async Task<List<RoomDTO>> GetRooms()
        {
            var rooms = await _context.Rooms.Include(r => r.RoomAmenities).ToListAsync();

            var roomsDTO = rooms.Select(r => new RoomDTO
            {
                Id = r.ID,
                Name = r.Name,
                NickName = r.NickName,
                Price = r.Price,
                PetFriendly = r.PetFriendly
            }).ToList();

            return roomsDTO;
        }

   

        public async Task<Room> UpdateRoom(int roomId, Room room)
        {
              _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return room;
        }



        public async Task Delete(int roomId)
        {
            Room room = await _context.Rooms.FindAsync(roomId);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }




        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity()
            {
                roomId = roomId,
                amenityId = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();

        }

     

        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            // Find me the record where the room and amenity match our request
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(r => r.amenityId == amenityId && r.roomId == roomId);

            _context.Entry(result).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }


      




    }
}

