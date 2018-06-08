﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
    public class Snapshot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Required]
        public int RoomCount { get; set; }

        [Required]
        public int UserCount { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Location { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
    }
}
