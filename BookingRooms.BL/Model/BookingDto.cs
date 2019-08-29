using BookingRooms.DAL;
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

        [Required]
        public int EmployeeId { get; set; }

        public string EmployeeUsername { get; set; }

        [Required]
        public int RoomId { get; set; }

        public string RoomName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime BookedFrom { get; set; }

        [Required]
        public DateTime BookedTo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
