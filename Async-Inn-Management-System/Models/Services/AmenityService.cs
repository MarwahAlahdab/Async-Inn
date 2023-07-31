using System;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Services
{
	public class AmenityService : IAmenity
	{
        private readonly AsyncInnDbContext _context;

        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<AmenityDTO> Create(AmenityDTO amenityDTO)
        {
            var amenity = new Amenity
            {
                
                Name = amenityDTO.Name,
            };

            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();

  
            AmenityDTO addedAmenity = await GetAmenity(amenity.ID);

            return addedAmenity;

        }


        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var amenities = await _context.Amenities.Include(a => a.RoomAmenities).ToListAsync();
            //return amenities;

            var amenityDTOs = amenities.Select(a => new AmenityDTO
            {
                ID = a.ID,
                Name = a.Name


            }).ToList();
            return amenityDTOs;

       
        }



        public async Task<AmenityDTO> GetAmenity(int amenityId)
        {
            Amenity amenity = await _context.Amenities.FindAsync(amenityId);

            if (amenity == null)
            {
                return null;
            }

            var amenityDTO = new AmenityDTO
            {
                ID = amenity.ID,
                Name = amenity.Name,
            };

            return amenityDTO;
        }


     

        public async Task<Amenity> UpdateAmenity(int amenityId, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task Delete(int amenityId)
        {
            Amenity amenity = await _context.Amenities.FindAsync(amenityId); 
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


        


    }
}

