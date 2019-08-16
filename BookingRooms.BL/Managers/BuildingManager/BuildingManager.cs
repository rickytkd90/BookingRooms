using BookingRooms.BL.Model;
using BookingRooms.Common;
using BookingRooms.DAL;
using BookingRooms.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Managers
{
    public class BuildingManager : IBuildingManager
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingManager()
        {
            _buildingRepository = new UnitOfWork().BuildingRepository;
        }

        private BuildingDto MapTo(Building b)
        {
            return new BuildingDto()
            {
                Id = b.Id,
                Name = b.Name,
                Address = b.Address,
                City = b.City,
                IsAvailable = b.IsAvailable,
                CreatedOn = b.CreatedOn.Value,
                UpdatedOn = b.UpdatedOn.Value
            };
        }

        private Building MapFrom(BuildingDto b)
        {
            return new Building()
            {
                Id = b.Id,
                Name = b.Name,
                Address = b.Address,
                City = b.City,
                IsAvailable = b.IsAvailable,
                CreatedOn = b.CreatedOn,
                UpdatedOn = b.UpdatedOn
            };
        }

        public void InsertBuilding(BuildingDto b)
        {
            try
            {
                //check if exist building with the same name
                var exist = _buildingRepository.GetAll().Any(x => x.Name.ToLower() == b.Name.ToLower());

                if (!exist)
                {
                    var newB = new Building()
                    {
                        Name = b.Name,
                        Address = b.Address,
                        City = b.City,
                        IsAvailable = b.IsAvailable,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    };

                    _buildingRepository.Add(newB);

                    LogManager.Debug($"Inserito nuovo edificio (Name:{newB.Name}, Address:{newB.Address}, City:{newB.City})");
                }
                else
                {
                    throw new Exception($"E' già presente un edificio con nome {b.Name}");
                }
            }
            catch(Exception ex)
            {
                LogManager.Error(ex);
                throw ex;
            }
        }

        public BuildingDto GetBuildingById(int id)
        {
            var b = _buildingRepository.GetById(id);

            if (b != null)
                return MapTo(b);

            LogManager.Warning($"Nessun edificio trovato (id:{id})");
            return null;
        }

        public IEnumerable<BuildingDto> GetBuildings()
        {
            return _buildingRepository.GetAll().Select(b => MapTo(b));
        }
    }
}
