using System;
using System.Collections.Generic;

namespace MockProject3.DAL.Models
{
    public partial class Rooms
    {
        public Rooms()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
