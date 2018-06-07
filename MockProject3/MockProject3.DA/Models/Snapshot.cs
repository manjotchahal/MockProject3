using System;
using System.Collections.Generic;
using System.Text;

namespace MockProject3.DA.Models
{
    public class Snapshot
    {
        public DateTime Date { get; set; }

        public int RoomCount { get; set; }

        public int UserCount { get; set; }

        public string Location { get; set; }
    }
}
