using System;
using System.Collections.Generic;
using System.Text;
using MockProject3.DA.Models;

namespace MockProject3.DA.IRepos
{
    public interface IRoomRepo
    {
        Room GetRoomByDate(DateTime datetime);
        IEnumerable<Room> GetRooms();
        IEnumerable<Room> GetRoomsByDate(DateTime datetime);
        IEnumerable<Room> GetRoomsBetweenDates(DateTime Start, DateTime End);
        IEnumerable<Room> GetRoomsBetweenDatesAtLocation(DateTime Start, DateTime End, string location);
    }
}
