using System;
namespace Async_Inn_Management_System.Models.Interfaces
{
	public interface IAmenity
	{
        //create
        Task<Amenity> Create(Amenity amenity);

        //GET all
        Task<List<Amenity>> GetAmenities();

        //GET by id
        Task<Amenity> GetAmenity(int amenityId);

        //Update
        Task<Amenity> UpdateAmenity(int amenityId, Amenity amenity);

        //Delete
        Task Delete(int amenityId);
    }
}

