using System;
using System.Collections.Generic;
using System.Text;
using MockProject3.DAL.Models;

namespace MockProject3.DAL
{
    class Test
    {
        public static void Main(string[] args)
        {
            ForecastDB1Context db = new ForecastDB1Context();
            var room = new Rooms()
            {
                Address = "123 address st tampa, fl 33612",
                Capacity = 6,
                Gender = "Male",
                Created = DateTime.Now,
                Modified = DateTime.Now
            };
            db.Rooms.Add(room);
            db.SaveChanges();
        }
    }
}
