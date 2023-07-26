using System;
namespace Async_Inn_Management_System.Models.Interfaces
{

	public interface IHotelRoom
	{
       

        Task<HotelRoom> AddHotelRoom(HotelRoom hotelRoom);

        Task<HotelRoom> GetHotelRoom(int roomId, int hotelId);

        Task<List<HotelRoom>> GetAllHotelRooms(int hotelId);

        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);

        Task DeleteHotelRoom(int roomId, int hotelId);
    }
}

