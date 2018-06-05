using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MockProject3.DA.Models
{
    public class Users
    {
        public int UserID { get; set; }
        [Required]
        public int BatchID { get; set; }
        public int RoomID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
    }

}
