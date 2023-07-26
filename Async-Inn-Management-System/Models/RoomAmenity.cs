using System;
namespace Async_Inn_Management_System.Models
{
	public class RoomAmenity
	{

		public int roomId;
		public int amenityId;

		public Room Room { get; set; }
		public Amenity Amenity { get; set; }


		public RoomAmenity()
		{
		}
	}
}

