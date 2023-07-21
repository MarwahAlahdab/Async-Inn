﻿using System;
using Async_Inn_Management_System.Data;
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

        public async Task<Room> Create(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

       

        public async Task<Room> GetRoom(int roomId)
        {
            Room room = await _context.Rooms.FindAsync(roomId);
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> UpdateRoom(int roomId, Room room)
        {
              _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return room;
        }



        public async Task Delete(int roomId)
        {
            Room room = await GetRoom(roomId);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

      

    }
}

