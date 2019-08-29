using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Model
{
    /// <summary>
    /// Contains all the room data
    /// </summary>
    public class RoomDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int SeatsNumber { get; set; }

        public int BuildingId { get; set; }

        public string BuildingName { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
