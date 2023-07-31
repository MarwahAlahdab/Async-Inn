using System;
using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Interfaces
{

	public interface IHotelRoom
	{
       

        Task<HotelRoomDTO> AddHotelRoom(HotelRoomDTO hotelRoomDTO);

        Task<HotelRoomDTO> GetHotelRoom(int roomId, int hotelId);

        Task<List<HotelRoomDTO>> GetAllHotelRooms(int hotelId);

        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);

        Task DeleteHotelRoom(int roomId, int hotelId);
    }
}

