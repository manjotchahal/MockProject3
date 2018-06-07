using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
    [Table("Name")]
    public class Name 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        public Guid NameId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string First { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Middle { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Last { get; set; }

        public ICollection<User> Users { get; set; }
    }

}
