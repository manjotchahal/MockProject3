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
        public int Id { get; set; }

        // Name of the batch
        [Required(AllowEmptyStrings = false, ErrorMessage = "The batch name is required")]
        [DataType(DataType.Text)]
        [Column(TypeName ="nvarchar(MAX)")] // The column is nvarchar with MAX length possible in SQL
        public string Name { get; set; }

        // The total of the associates in the batch
        [Required(ErrorMessage = "The batch name is required")]
        public int Total { get; set; }

        // The Technology the batch will be learning
        [Required(AllowEmptyStrings = false, ErrorMessage = "Technology is required")]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")] // The column is nvarchar with MAX length possible in SQL
        public string Technology { get; set; }

        // The start date of the batch
        [Required(AllowEmptyStrings = false, ErrorMessage = "The start date is required")]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime")] // The column is of datetime
        public DateTime? StartDate { get; set; }

        // The Expected date of the batch finishing
        [Required(AllowEmptyStrings = false, ErrorMessage = "The end date is required")]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime")] // The column is of datetime
        public DateTime? EndDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
