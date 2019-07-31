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
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager()
        {
            _roomRepository = new UnitOfWork().RoomRepository;
        }

        private RoomDto MapTo(Room r)
        {
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

        private Room MapFrom(RoomDto r)
        {
            return new Room()
            {
                Id = r.Id,
                Name = r.Name,
                SeatsNumber = r.SeatsNumber,
                IsAvailable = r.IsAvailable,
                CreatedOn = r.CreatedOn,
                UpdatedOn = r.UpdatedOn
            };
        }


        public void InsertRoom(RoomDto r)
        {
            try
            {
                //check if exist room with the same name
                var exist = _roomRepository.GetAll().Any(x => x.Name == r.Name);

                if (!exist)
                {
                    var newR = new Room()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        SeatsNumber = r.SeatsNumber,
                        IsAvailable = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    };

                    _roomRepository.Insert(newR);

                    LogManager.Debug($"Inserita nuova stanza (Name:{newR.Name})");

                }
                else
                {
                    LogManager.Warning($"E' già presente una stanza con nome {r.Name})");
                }

            }
            catch(Exception ex)
            {
                LogManager.Error(ex.Message);
            }

        }

        public RoomDto GetRoomById(int id)
        {
            return MapTo(_roomRepository.GetById(id));
        }

        public IEnumerable<RoomDto> GetRooms()
        {
            return _roomRepository.GetAll().Select(r => MapTo(r));
        }
    }
}
