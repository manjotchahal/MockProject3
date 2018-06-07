﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateModified { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateDeleted { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        [StringLength(200, ErrorMessage = "Address cannot be more than 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        [StringLength(200, ErrorMessage = "Location cannot be more than 200 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Gender { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
