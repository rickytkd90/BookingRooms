using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRooms.BL.Model;
using BookingRooms.DAL;
using BookingRooms.DAL.Repositories;

namespace BookingRooms.BL.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager()
        {
            _employeeRepository = new UnitOfWork().EmployeeRepository;
        }

        public void InsertEmployee(EmployeeDto employee)
        {

            if(employee != null)
            {

                //check Id
                Employee e = _employeeRepository.GetById(employee.Id);
                if (e != null)
                {
                    throw new ArgumentException($"Identificativo già presente. Utilizzare un altro valore (Suggerito: {_employeeRepository.GetNewId()}", "Employee.Id");
                }

                Employee newEmployee = new Employee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Username = GenerateUsername(employee.Name, employee.Surname),
                    EmailAddress = GenerateEmailAddress(employee.Name, employee.Surname),
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                _employeeRepository.Insert(newEmployee);

            };
        }

        public string GenerateUsername(string name, string surname)
        {
            var us1 = (surname.Length >= 5) ? surname.Substring(0, 5) : surname;
            var us2 = name.Substring(0, 2);
            var us3 = 1;

            while (true)
            {
                var username = $"{us1}{us2}{us3}".ToLower();
                if (_employeeRepository.GetEmployeeByUsername(username) == null)
                    return username;
                us3++;
            }
        }

        public string GenerateEmailAddress(string name, string surname)
        {
            var k = 0;
            var emailAddress = string.Empty;
            var domain = ConfigurationManager.AppSettings.Get("emailDomain");
            while (true)
            {
                if(k==0)
                    emailAddress = $"{name}.{surname}{domain}".ToLower();
                else
                    emailAddress = $"{name}.{surname}{k.ToString()}{domain}".ToLower();

                if (_employeeRepository.GetEmployeeByEmailAddress(emailAddress) == null)
                    return emailAddress;
                k++;
            }
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            Employee e = _employeeRepository.GetById(id);

            return new EmployeeDto()
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                UserName = e.Username,
                EmailAddress = e.EmailAddress,
                IsAvailable = e.IsAvailable,
                CreatedOn = e.CreatedOn.Value,
                UpdatedOn = e.UpdatedOn.Value
            };
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return _employeeRepository.GetAll().Select(e => new EmployeeDto() {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                UserName = e.Username,
                EmailAddress = e.EmailAddress,
                IsAvailable = e.IsAvailable,
                CreatedOn = e.CreatedOn.Value,
                UpdatedOn = e.UpdatedOn.Value
            });
        }
    }
}
