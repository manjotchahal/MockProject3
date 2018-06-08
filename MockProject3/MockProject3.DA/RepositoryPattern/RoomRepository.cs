using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MockProject3.DA;
using MockProject3.DA.Models;

namespace MockProject3.DA.RepositoryPattern
{
    public class RoomRepository : IRepository<Room>, IDisposable
    {
        private ForecastContext _context;

        public RoomRepository(ForecastContext db = null)
        {
            _context = db ?? new ForecastContext();
        }

        private bool RoomExists(Guid id)
        {
            return _context.Rooms.Count(e => e.RoomId == id) > 0;
        }

        public IQueryable<Room> Get()
        {
            return _context.Rooms;
        }

        public Room Get(Guid id)
        {

            Room Room = _context.Rooms.Find(id);
            if (Room == null)
            {
                return null;
            }
            return Room;
        }
        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }
}