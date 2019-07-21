using BookingRooms.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Managers
{
    public interface IEmployeeManager
    {
        void InsertEmployee(EmployeeDto employee);
        EmployeeDto GetEmployeeById(int id);
        IEnumerable<EmployeeDto> GetEmployees();
        string GenerateUsername(string name, string surname);
        string GenerateEmailAddress(string name, string surname);
    }
}
