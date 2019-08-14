﻿using BookingRooms.BL.Model;
using BookingRooms.Common;
using BookingRooms.DAL;
using BookingRooms.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Id = b.Id,
                EmployeeId = b.EmployeeId,
                EmployeeUsername = b.Employee.Username,
                RoomId = b.RoomId,
                RoomName = b.Room.Name,
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
                Id = b.Id,
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
            try
            {
                //check if the reservation already exists for the room
                var exist = (
                    _bookingRepository.GetAll()
                    .Where(
                        x => 
                            x.RoomId == b.RoomId &&
                            x.BookedFrom >= b.BookedFrom && 
                            x.BookedTo <= b.BookedTo 
                     ).Count()) > 0;

                //insert the riservation if room is available
                if (!exist)
                {
                    Booking newB = new Booking()
                    {
                        EmployeeId = b.EmployeeId,
                        RoomId = b.RoomId,
                        Description = b.Description,
                        BookedFrom = b.BookedFrom,
                        BookedTo = b.BookedTo,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    };

                    _bookingRepository.Add(newB);

                    LogManager.Debug($"Inserita nuova prenotazione: (RoomId:{newB.RoomId}, From:{newB.BookedFrom}, To:{newB.BookedTo})");
                }
                else
                {
                    throw new Exception($"Impossibile inserire la prenotazione. La sala è già prenotata");
                }
            }
            catch(Exception ex)
            {
                LogManager.Error(ex);
                throw ex;
            }
        }

        public BookingDto GetBookingById(int id)
        {
            var b = _bookingRepository.GetBookingById(id);

            if (b != null)
                return MapTo(b);

            LogManager.Warning($"Nessuna prenotazione trovata (id:{id})");
            return null;
        }

        public IEnumerable<BookingDto> GetBookings()
        {
            return _bookingRepository.GetAllBookings().Select(b => MapTo(b));
        }

        public void DeleteBooking(int id)
        {
            try
            {
                _bookingRepository.DeleteById(id);
                LogManager.Debug($"Prenotazione Cancellata (id:{id})");
            }
            catch(Exception ex)
            {
                LogManager.Error($"Impossibile cancellare la prenotazione (id:{id}");
                LogManager.Error(ex);
                throw ex;
            }
        }
    }
}
