using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookingRooms.DAL.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingRoomsEntities dbContext) : base(dbContext) { }

        public IEnumerable<Booking> GetAllBookings()
        {
            return dbContext.Bookings
                .Include(o => o.Room)
                .Include(o => o.Employee)
                .ToList();
        }

        public Booking GetBookingById(int id)
        {
            return dbContext.Bookings
                .Include(o => o.Room)
                .Include(o => o.Employee)
                .SingleOrDefault(o => o.Id == id);
        }
    }
}
