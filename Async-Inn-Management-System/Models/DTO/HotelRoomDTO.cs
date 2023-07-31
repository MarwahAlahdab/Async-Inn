using System;
namespace Async_Inn_Management_System.Models.DTO
{
	public class HotelRoomDTO
	{
     

        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public bool State { get; set; }

        public HotelDTO Hotel { get; set; }
        public RoomDTO Room { get; set; }
        public RoomLayout Layout { get; set; }





    }
}

