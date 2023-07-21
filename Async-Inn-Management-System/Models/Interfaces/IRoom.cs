using System;
namespace Async_Inn_Management_System.Models.Interfaces
{
	public interface IRoom
	{
        //create
        Task<Room> Create(Room room);

        //GET all
        Task<List<Room>> GetRooms();

        //GET by id
        Task<Room> GetRoom(int roomId);

        //Update
        Task<Room> UpdateRoom(int roomId, Room room);

        //Delete
        Task Delete(int roomId);
    }
}

