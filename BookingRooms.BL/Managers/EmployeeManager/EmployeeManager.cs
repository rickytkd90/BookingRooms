﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public void InsertEmployee(EmployeeDto e)
        {
            try
            {
                //check if already exist employee with the same id
                var exist = _employeeRepository.GetAll().Any(x => x.Id == e.Id);

                if (!exist)
                {
                    Employee newEmployee = new Employee()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Surname = e.Surname,
                        Username = GenerateUsername(e.Name, e.Surname),
                        EmailAddress = GenerateEmailAddress(e.Name, e.Surname),
                        IsAvailable = e.IsAvailable,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    };

                    _employeeRepository.Add(newEmployee);

                    LogManager.Debug($"Inserita nuova risorsa (Id:{newEmployee.Id}, Username:{newEmployee.Username}, Email:{newEmployee.EmailAddress})");

                }
                else
                {
                    throw new Exception($"E' già presente una risorsa con id:{e.Id}");
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
            //normalize input
            surname = Regex.Replace(surname, @"[^0-9a-zA-Z]+", "").Trim().ToLower();
            name = Regex.Replace(name, @"[^0-9a-zA-Z]+", "").Trim().ToLower();

            var us1 = (surname.Length >= 5) ? surname.Substring(0, 5) : surname;
            var us2 = (name.Length >= 2) ? name.Substring(0, 2) : name;
            var us3 = 1;

            while (true)
            {
                var username = $"{us1}{us2}{us3}";
                if (_employeeRepository.Find(x => x.Username == username).Count() == 0)
                    return username;
                us3++;
            }
        }

        public string GenerateEmailAddress(string name, string surname)
        {
            var k = 0;
            var emailAddress = string.Empty;
            var domain = ConfigurationManager.AppSettings.Get("emailDomain");
            surname = Regex.Replace(surname, @"[^0-9a-zA-Z]+", "").Trim().ToLower();
            name = Regex.Replace(name, @"[^0-9a-zA-Z]+", "").Trim().ToLower();

            while (true)
            {
                if(k==0)
                    emailAddress = $"{name}.{surname}{domain}";
                else
                    emailAddress = $"{name}.{surname}{k.ToString()}{domain}";

                if (_employeeRepository.Find(x => x.EmailAddress == emailAddress).Count() == 0)
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
