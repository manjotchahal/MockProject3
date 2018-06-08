using MockProject3.DA.IRepos;
using MockProject3.DA.Models;
using System;
using System.Collections.Generic;
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

        public Room GetRoomByDate(DateTime datetime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRooms()
        {
            return _context.Rooms;
        }

        public IEnumerable<Room> GetRoomsBetweenDates(DateTime Start, DateTime End)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRoomsBetweenDatesAtLocation(DateTime Start, DateTime End, string location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRoomsByDate(DateTime datetime)
        {
            throw new NotImplementedException();
        }
    }
}
