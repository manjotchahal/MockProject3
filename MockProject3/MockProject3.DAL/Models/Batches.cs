using System;
using System.Collections.Generic;

namespace MockProject3.DAL.Models
{
    public partial class Batches
    {
        public Batches()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public string Technology { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
