using System;
namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotel
    {
        //create
        Task<Hotel> Create(Hotel hotel);

        //GET all
        Task<List<Hotel>> GetHoteles();

        //GET by id
        Task<Hotel> GetHotel(int hotelId);

        //Update
        Task<Hotel> UpdateHotel(int hotelId, Hotel hotel);

        //Delete
        Task Delete(int hotelId);

    }
}

 