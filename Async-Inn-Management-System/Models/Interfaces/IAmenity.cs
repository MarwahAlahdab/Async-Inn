using System;
using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Interfaces
{
	public interface IAmenity
	{
        //create
        Task<AmenityDTO> Create(AmenityDTO amenityDTO);

        //GET all
        Task<List<AmenityDTO>> GetAmenities();

        //GET by id
        Task<AmenityDTO> GetAmenity(int amenityId);

        //Update
        Task<Amenity> UpdateAmenity(int amenityId, Amenity amenity);

        //Delete
        Task Delete(int amenityId);
    }
}

