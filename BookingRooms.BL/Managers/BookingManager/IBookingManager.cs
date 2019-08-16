using BookingRooms.BL.Model;
using BookingRooms.DAL;
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
        void DeleteBooking(int id);
    }
}
