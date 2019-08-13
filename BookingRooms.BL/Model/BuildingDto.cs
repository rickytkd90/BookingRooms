using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Model
{
    /// <summary>
    /// Contains all the Building data
    /// </summary>
    public class BuildingDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Building Name must be submitted")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Building Address must be submitted")]
        [StringLength(100, ErrorMessage = "Address length can't be more than 100")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Building City must be submitted")]
        [StringLength(100, ErrorMessage = "City length can't be more than 100")]
        public string City { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
