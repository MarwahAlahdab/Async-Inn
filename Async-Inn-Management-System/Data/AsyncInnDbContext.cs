using System;
using Async_Inn_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using Async_Inn_Management_System.Models.Interfaces;
using Async_Inn_Management_System.Models.Services;

namespace Async_Inn_Management_System.Data
{
    public class AsyncInnDbContext : DbContext
    {


        //public AsyncInnDbContext()
        //{

        //}
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

       


            modelBuilder.Entity<Hotel>().HasData(
        new Hotel { ID = 1, Name = "Hotel 1", StreetAddress = "Address 1", City = "City 1", State = "State 1", Country = "Country 1", Phone = "Phone 1" },
        new Hotel { ID = 2, Name = "Hotel 2", StreetAddress = "Address 2", City = "City 2", State = "State 2", Country = "Country 2", Phone = "Phone 2" },
        new Hotel { ID = 3, Name = "Hotel 3", StreetAddress = "Address 3", City = "City 3", State = "State 3", Country = "Country 3", Phone = "Phone 3" }
    );

            modelBuilder.Entity<Room>().HasData(
           new Room { ID = 1, Name = "Room 1", NickName = "Nickname 1", Price = 100.0, PetFriendly = true },
           new Room { ID = 2, Name = "Room 2", NickName = "Nickname 2", Price = 120.0, PetFriendly = false },
           new Room { ID = 3, Name = "Room 3", NickName = "Nickname 3", Price = 150.0, PetFriendly = true }
       );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { ID = 1, Name = "Amenity 1" },
                new Amenity { ID = 2, Name = "Amenity 2" },
                new Amenity { ID = 3, Name = "Amenity 3" }
            );

            modelBuilder.Entity<RoomAmenity>().HasKey(
           RoomAmenity => new {
               RoomAmenity.roomId,
               RoomAmenity.amenityId
           }
           );

               modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.RoomId, hr.HotelId });





        }




    }


   

}

