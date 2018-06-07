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

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateModified { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateDeleted { get; set; }

        public int Capacity { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Location { get; set; }

        public int Vacancy { get; set; }

        public int Occupancy { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]        
        [Required]
        public string Gender { get; set; }

        [Required]
        public Address Address { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Deleted { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
