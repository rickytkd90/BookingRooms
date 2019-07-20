using BookingRooms.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        private BookingRoomsEntities _dbContext;
        private IBookingRepository _bookingRepository;
        private IRoomRepository _roomRepository;
        private IEmployeeRepository _employeeRepository;
        private IBuildingRepository _buildingRepository;
        private bool _dispose = false;

        public UnitOfWork()
        {
            _dbContext = new BookingRoomsEntities();
            _dbContext.Configuration.LazyLoadingEnabled = false;
        }

        public IBookingRepository BookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                {
                    _bookingRepository = new BookingRepository(_dbContext);
                }
                return _bookingRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_dbContext);
                }
                return _employeeRepository;
            }
        }

        public IRoomRepository RoomRepository
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new RoomRepository(_dbContext);
                }
                return _roomRepository;
            }
        }

        public IBuildingRepository BuildingRepository
        {
            get
            {
                if (_buildingRepository == null)
                {
                    _buildingRepository = new BuildingRepository(_dbContext);
                }
                return _buildingRepository;
            }
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (_dispose)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Save

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #endregion Save
    }
}
