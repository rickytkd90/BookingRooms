using BookingRooms.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Managers
{
    public interface IBuildingManager
    {
        void InsertBuilding(BuildingDto building);
        BuildingDto GetBuildingById(int id);
        IEnumerable<BuildingDto> GetBuildings();
    }
}
