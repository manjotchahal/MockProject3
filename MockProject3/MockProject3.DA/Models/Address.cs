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
            public Guid Id { get; set; }
            public Guid AddressId { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            public string Address1 { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            public string Address2 { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            public string City { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            public string State { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            public string PostalCode { get; set; }
            [DataType(DataType.Text)]
            [Column(TypeName = "nvarchar(MAX)")]
            public string Country { get; set; }
        }
}
