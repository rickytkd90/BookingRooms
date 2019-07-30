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
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager()
        {
            _roomRepository = new UnitOfWork().RoomRepository;
        }

        public void InsertRoom(RoomDto room)
        {

            if (room != null)
            {

                Room newRoom = new Room()
                {
                    Id = room.Id,
                    Name = room.Name,
                    SeatsNumber = room.SeatsNumber,
                    IsAvailable = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                _roomRepository.Insert(newRoom);

            };
        }

        public RoomDto GetRoomById(int id)
        {
            Room r = _roomRepository.GetById(id);

            return new RoomDto()
            {
                Id = r.Id,
                Name = r.Name,
                SeatsNumber = r.SeatsNumber,
                IsAvailable = r.IsAvailable,
                CreatedOn = r.CreatedOn.Value,
                UpdatedOn = r.UpdatedOn.Value
            };
        }

        public IEnumerable<RoomDto> GetRooms()
        {
            return _roomRepository.GetAll().Select(r => new RoomDto()
            {
                Id = r.Id,
                Name = r.Name,
                SeatsNumber = r.SeatsNumber,
                IsAvailable = r.IsAvailable,
                CreatedOn = r.CreatedOn.Value,
                UpdatedOn = r.UpdatedOn.Value
            });
        }
    }
}
