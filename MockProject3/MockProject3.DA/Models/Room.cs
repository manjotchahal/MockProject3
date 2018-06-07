using System;
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
        public Guid Id { get; set; }
        
        // Id we get from service hub
        public Guid RoomId { get; set; }

        public int Capacity { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Location { get; set; }

        public Guid AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public int Vacancy { get; set; }

        public int Occupancy { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public char Gender { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Deleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
