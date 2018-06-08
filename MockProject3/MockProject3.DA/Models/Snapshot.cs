using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
    ///<summary>The Snapshot class is used to represent the supply and demand of Rooms and Users on any given date.</summary>
    [Table("Snapshots")]
    public class Snapshot
    {
        public DateTime Date { get; set; }

        public int RoomCount { get; set; }

        public int UserCount { get; set; }

        public string Location { get; set; }
    }
}
