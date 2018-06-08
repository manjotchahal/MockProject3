using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
    [Table("Batches")]
    public class Batch
    {
        [Key] // The primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto increment the primary key
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        public Guid BatchId { get; set; }

        // The start date of the batch
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")] // The column is of datetime
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")] // The column is of datetime
        public DateTime EndDate { get; set; }

        // Name of the batch
        [DataType(DataType.Text)]
        [Required]
        [Column(TypeName ="nvarchar(MAX)")] // The column is nvarchar with MAX length possible in SQL
        public string BatchName { get; set; }

        // The total of the associates in the batch
        [Range(0, 100)]
        [Required]
        public int BatchOccupancy { get; set; }

        // The Technology the batch will be learning
        [DataType(DataType.Text)]
        [Required]
        [Column(TypeName = "nvarchar(MAX)")] // The column is nvarchar with MAX length possible in SQL
        public string BatchSkill { get; set; }

        [Required]
        public Address Address { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Deleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
