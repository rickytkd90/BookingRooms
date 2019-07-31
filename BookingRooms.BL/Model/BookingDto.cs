using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Model
{
    /// <summary>
    /// Contains all the Booking data
    /// </summary>
    public class BookingDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RoomId { get; set; }
        public string Description { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
