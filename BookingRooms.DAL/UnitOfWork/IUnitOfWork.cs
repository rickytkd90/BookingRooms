using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
