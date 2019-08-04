using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(BookingRoomsEntities dbContext) : base(dbContext) {}

        public int GetNewId()
        {
            return dbSet.Max(x => x.Id);
        }
    }
}
