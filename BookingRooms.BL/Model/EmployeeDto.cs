﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Model
{
    /// <summary>
    /// Contains all the Employee data
    /// </summary>
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee Name must be submitted")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee Surname must be submitted")]
        [StringLength(50, ErrorMessage = "Surname length can't be more than 50")]
        public string Surname { get; set; }

        public string Username { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
