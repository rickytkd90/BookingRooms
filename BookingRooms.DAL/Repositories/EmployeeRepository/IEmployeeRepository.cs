using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.DAL.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetEmployeeByUsername(string username);
        Employee GetEmployeeByEmailAddress(string emailAddress);
        int GetNewId();
    }
}
