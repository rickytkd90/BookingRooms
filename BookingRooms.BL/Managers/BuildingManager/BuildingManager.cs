using BookingRooms.BL.Model;
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

        public void InsertBuilding(BuildingDto building)
        {

            if (building != null)
            {

                Building newBuilding = new Building()
                {
                    Name = building.Name,
                    Address = building.Address,
                    City = building.City,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                _buildingRepository.Insert(newBuilding);

            };
        }

        public BuildingDto GetBuildingById(int id)
        {
            Building b = _buildingRepository.GetById(id);

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

        public IEnumerable<BuildingDto> GetBuildings()
        {
            return _buildingRepository.GetAll().Select(b => new BuildingDto()
            {
                Id = b.Id,
                Name = b.Name,
                Address = b.Address,
                City = b.City,
                IsAvailable = b.IsAvailable,
                CreatedOn = b.CreatedOn.Value,
                UpdatedOn = b.UpdatedOn.Value
            });
        }
    }
}
