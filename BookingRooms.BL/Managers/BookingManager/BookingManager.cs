using BookingRooms.BL.Model;
using BookingRooms.Common;
using BookingRooms.DAL;
using BookingRooms.DAL.Repositories;
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

        private BookingDto MapTo(Booking b)
        {
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

        private Booking MapFrom(BookingDto b)
        {
            return new Booking()
            {
                id = b.Id,
                EmployeeId = b.EmployeeId,
                RoomId = b.RoomId,
                Description = b.Description,
                BookedFrom = b.BookedFrom,
                BookedTo = b.BookedTo,
                CreatedOn = b.CreatedOn, 
                UpdatedOn = b.UpdatedOn
            };
        }

        public void InsertBooking(BookingDto b)
        {

            //check if the reservation already exists for the room
            var existBooking = (_bookingRepository.GetAll().Where(X => b.BookedFrom >= b.BookedFrom && b.BookedTo <= b.BookedTo && b.RoomId == b.RoomId).Count()) > 0;

            //insert the riservation if room is available
            if (!existBooking)
            {
                Booking newB = new Booking()
                {
                    id = b.Id,
                    EmployeeId = b.EmployeeId,
                    RoomId = b.RoomId,
                    Description = b.Description,
                    BookedFrom = b.BookedFrom,
                    BookedTo = b.BookedTo,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                _bookingRepository.Insert(newB);

                LogManager.Debug($"Inserita nuova prenotazione: (RoomId:{newB.RoomId}, From:{newB.BookedFrom}, To:{newB.BookedTo})");
            }
            else
            {
                LogManager.Warning($"Impossibile inserire la prenotazione. La sala è già prenotata (RoomId:{b.RoomId}, From:{b.BookedFrom}, To:{b.BookedTo})");
            }
            
        }

        public BookingDto GetBookingById(int id)
        {
            BookingDto result = null;

            try
            {
                var b = _bookingRepository.GetById(id);
                result =  MapTo(b);
            }
            catch(Exception ex)
            {
                LogManager.Error(ex.Message);
                throw ex;
            }

            return result;
        }

        public IEnumerable<BookingDto> GetBookings()
        {
            return _bookingRepository.GetAll().Select(b => MapTo(b));
        }

        public void DeleteBooking(int id)
        {
            try
            {
                _bookingRepository.DeleteById(id);
            }
            catch(Exception ex)
            {
                LogManager.Error($"Impossibile cancellare la prenotazione (id:{id}");
                throw ex;
            }
           
        }


    }
}
