using System;
using Async_Inn_Management_System.Models.Services;

namespace Async_Inn_Management_System.Models
{
    public class Room
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public double Price { get; set; }
        public bool PetFriendly { get; set; }


        //NP
        public List <RoomAmenity> RoomAmenities { get; set; }
        public List <HotelRoom> HotelRooms { get; set; }


        public Room()
        {
        }
    }
}

