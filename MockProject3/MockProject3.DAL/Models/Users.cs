using System;
using System.Collections.Generic;

namespace MockProject3.DAL.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? RoomId { get; set; }
        public int? BatchId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public Batches Batch { get; set; }
        public Rooms Room { get; set; }
    }
}
