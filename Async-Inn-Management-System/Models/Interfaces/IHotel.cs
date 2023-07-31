using System;
using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotel
    {
        //create
        Task<HotelDTO> Create(HotelDTO hotelDTO);

        //GET all
        Task<List<HotelDTO>> GetHoteles();

        //GET by id
        Task<HotelDTO> GetHotel(int hotelId);

        //Update
        Task<Hotel> UpdateHotel(int hotelId, Hotel hotel);

        //Delete
        Task Delete(int hotelId);

    }
}

 