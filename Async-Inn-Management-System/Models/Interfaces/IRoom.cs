using System;
using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Interfaces
{
	public interface IRoom
	{
        //create
        Task<RoomDTO> Create(RoomDTO roomDTO);

        //GET all
        Task<List<RoomDTO>> GetRooms();

        //GET by id
        Task<RoomDTO> GetRoom(int roomId);

        //Update
        Task<Room> UpdateRoom(int roomId, Room room);

        //Delete
        Task Delete(int roomId);


        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmenityFromRoom(int roomId, int amenityId);
    }
}

