using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRooms.BL.Model;
using BookingRooms.Common;
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

        private EmployeeDto MapTo(Employee e)
        {
            return new EmployeeDto()
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Username = e.Username,
                EmailAddress = e.EmailAddress,
                IsAvailable = e.IsAvailable,
                CreatedOn = e.CreatedOn.Value,
                UpdatedOn = e.UpdatedOn.Value
            };
        }

        private Employee MapFrom(EmployeeDto e)
        {
            return new Employee()
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Username = e.Username,
                EmailAddress = e.EmailAddress,
                IsAvailable = e.IsAvailable,
                CreatedOn = e.CreatedOn,
                UpdatedOn = e.UpdatedOn
            };
        }

        public void InsertEmployee(EmployeeDto employee)
        {
            try
            {
                //check if already exist employee with the same id
                var e = _employeeRepository.GetById(employee.Id);

                if (e == null)
                {
                    Employee newEmployee = new Employee()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Surname = employee.Surname,
                        Username = GenerateUsername(employee.Name, employee.Surname),
                        EmailAddress = GenerateEmailAddress(employee.Name, employee.Surname),
                        IsAvailable = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    };

                    _employeeRepository.Insert(newEmployee);

                    LogManager.Debug($"Inserita nuova risorsa (Id:{newEmployee.Id}, Username:{newEmployee.Username}, Email:{newEmployee.EmailAddress})");

                }
                else
                {
                    LogManager.Warning($"Esiste già una risors con id:{employee.Id}");
                }
            }
            catch(Exception ex)
            {
                LogManager.Error(ex.Message);
                throw ex;
            }
            
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
            var e = _employeeRepository.GetById(id);

            if (e != null)
                return MapTo(e);

            return null;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return _employeeRepository.GetAll().Select(e => MapTo(e));
        }
    }
}
