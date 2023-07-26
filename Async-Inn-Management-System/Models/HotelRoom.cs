using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Async_Inn_Management_System.Models
{
	public class HotelRoom
	{
        public int Id { get; set; }


        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public Room Room { get; set; }
        public Hotel Hotel { get; set; }

        public bool State { get; set; }

        public HotelRoom()
		{
		}
	}
}

