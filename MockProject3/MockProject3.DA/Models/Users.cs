using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
    [Table("Users")]
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        public Guid userId { get; set; }

        public Guid nameId { get; set; }
        [ForeignKey("nameId")]
        public virtual Name Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string email { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(15)")]
        public string gender { get; set; }

        public string type { get; set; }

        public string location { get; set; }

        public Guid addressId { get; set; }
        [ForeignKey("addressId")]
        public Address Address { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateModified { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateDeleted { get; set; }
    }

}
