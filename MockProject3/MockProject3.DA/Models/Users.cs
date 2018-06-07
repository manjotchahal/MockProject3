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

        public Guid UserId { get; set; }

        public Guid NameId { get; set; }
        [ForeignKey("NameId")]
        public virtual Name Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(15)")]
        public string Gender { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public Guid AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Deleted { get; set; }
    }

}
