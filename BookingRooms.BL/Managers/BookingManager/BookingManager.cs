using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRooms.BL.Model;
using BookingRooms.DAL;
using BookingRooms.DAL.Repositories;

namespace BookingRooms.BL.Managers
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager()
        {
            _bookingRepository = new UnitOfWork().BookingRepository;
        }

        public void InsertBooking(BookingDto booking)
        {

            if (booking != null)
            {

                Booking newBooking = new Booking()
                {
                    Description = booking.Description,
                    BookedFrom = booking.BookedTo,
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
                Id = b.Id,
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
                Id = b.Id,
                Description = b.Description,
                BookedFrom = b.BookedFrom,
                BookedTo = b.BookedTo,
                CreatedOn = b.CreatedOn.Value,
                UpdatedOn = b.UpdatedOn.Value
            });
        }
    }
}
