using BookingRooms.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Managers
{
    public interface IBookingManager
    {
        void InsertBooking(BookingDto booking);
        BookingDto GetBookingById(int id);
        IEnumerable<BookingDto> GetBookings();
    }
}
