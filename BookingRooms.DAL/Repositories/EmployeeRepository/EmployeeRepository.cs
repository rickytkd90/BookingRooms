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

        public Employee GetEmployeeByUsername(string username)
        {
            return dbSet.Where(x => x.Username == username).SingleOrDefault();
        }

        public Employee GetEmployeeByEmailAddress(string emailAddress)
        {
            return dbSet.Where(x => x.EmailAddress == emailAddress).SingleOrDefault();
        }

        public int GetNewId()
        {
            return dbSet.Max(x => x.Id);
        }
    }
}
