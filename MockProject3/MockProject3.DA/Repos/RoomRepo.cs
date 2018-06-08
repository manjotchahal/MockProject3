using MockProject3.DA.IRepos;
using MockProject3.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockProject3.DA.Repos
{
    public class RoomRepo : IRoomRepo
    {
        private readonly ForecastContext _context;
        public RoomRepo(ForecastContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetRoomLocations()
        {
            return _context.Rooms.Select(r => r.Location).Where(r => r != null).Distinct();
        }

        public IEnumerable<Room> GetRooms()
        {
            return _context.Rooms;
        }

        public IEnumerable<Room> GetRoomsBetweenDates(DateTime Start, DateTime End)
        {
            return _context.Rooms.Where(r => r.Created <= Start && (r.Deleted > End || r.Deleted == null));
        }

        public IEnumerable<Room> GetRoomsBetweenDatesAtLocation(DateTime Start, DateTime End, string location)
        {
            return _context.Rooms.Where(r => r.Created <= Start && (r.Deleted > End || r.Deleted == null) && r.Location == location);
        }

        public IEnumerable<Room> GetRoomsByDate(DateTime datetime)
        {
            return _context.Rooms.Where(r => r.Created <= datetime && (r.Deleted == null || r.Deleted > datetime));
        }
    }
}
