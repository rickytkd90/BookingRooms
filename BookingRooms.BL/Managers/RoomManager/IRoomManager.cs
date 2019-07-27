using BookingRooms.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.BL.Managers
{
    public interface IRoomManager
    {
        void InsertRoom(RoomDto room);
        RoomDto GetRoomById(int id);
        IEnumerable<RoomDto> GetRooms();
    }
}
