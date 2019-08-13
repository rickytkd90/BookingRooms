using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookingRooms.DAL.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(BookingRoomsEntities dbContext) : base(dbContext) { }

        //Get Room by ID with foreign keys included
        public Room GetRoomById(int id)
        {
            return dbContext.Rooms
                .Include(o => o.Building)
                .SingleOrDefault(r => r.Id == id);
        }
    }
}
