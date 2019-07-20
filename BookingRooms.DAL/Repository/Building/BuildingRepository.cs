using BookingRooms.DAL.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.DAL.Repository
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(BookingRoomsEntities dbContext) : base(dbContext) { }
    }
}
