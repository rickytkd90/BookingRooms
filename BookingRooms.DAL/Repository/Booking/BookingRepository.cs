﻿using BookingRooms.DAL.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.DAL.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingRoomsEntities dbContext) : base(dbContext) { }
    }
}
