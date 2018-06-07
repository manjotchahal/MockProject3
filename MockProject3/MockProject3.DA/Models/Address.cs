using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
        public class Address
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }
            [Required]
            public Guid AddressId { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            [Required]
            [StringLength(255)]
            public string Address1 { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            public string Address2 { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            [Required]
            [StringLength(25)]
            public string City { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            [Required]
            [StringLength(2, MinimumLength=2)]
            public string State { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            [Required]
            [StringLength(5, MinimumLength=5)]
            public string PostalCode { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            [Required]
            [StringLength(2, MinimumLength=2)]
            public string Country { get; set; }
        }
}
