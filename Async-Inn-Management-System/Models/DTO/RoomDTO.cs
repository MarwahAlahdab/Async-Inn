﻿using System;
namespace Async_Inn_Management_System.Models.DTO
{
	public class RoomDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public double Price { get; set; }
        public bool PetFriendly { get; set; }
        public int HotelID { get; set; }

        public RoomLayout Layout { get; set; }


        public List<AmenityDTO> Amenities { get; set; }



    }
}

