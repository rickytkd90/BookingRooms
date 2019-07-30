using BookingRooms.BL.Model;
using BookingRooms.DAL;
using BookingRooms.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Managers
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager()
        {
            _bookingRepository = new UnitOfWork().BookingRepository;
        }

        public void InsertBuilding(BookingDto booking)
        {

            if (booking != null)
            {

                Booking newBooking = new Booking()
                {
                    id = booking.Id,
                    EmployeeId = booking.EmployeeId,
                    RoomId = booking.RoomId,
                    Description = booking.Description,
                    BookedFrom = booking.BookedFrom,
                    BookedTo = booking.BookedTo,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                _bookingRepository.Insert(newBooking);

            };
        }

        public BookingDto GetBookingById(int id)
        {
            Booking b = _bookingRepository.GetById(id);

            return new BookingDto()
            {
                Id = b.id,
                EmployeeId = b.EmployeeId,
                RoomId = b.RoomId,
                Description = b.Description,
                BookedFrom = b.BookedFrom,
                BookedTo = b.BookedTo,
                CreatedOn = b.CreatedOn.Value,
                UpdatedOn = b.UpdatedOn.Value
            };
        }

        public IEnumerable<BookingDto> GetBookings()
        {
            return _bookingRepository.GetAll().Select(b => new BookingDto()
            {
                Id = b.id,
                EmployeeId = b.EmployeeId,
                RoomId = b.RoomId,
                Description = b.Description,
                BookedFrom = b.BookedFrom,
                BookedTo = b.BookedTo,
                CreatedOn = b.CreatedOn.Value,
                UpdatedOn = b.UpdatedOn.Value
            });
        }
    }
}
