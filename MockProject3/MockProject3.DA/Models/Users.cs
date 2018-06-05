using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
    [Table("User")]
    public class Users 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int UserID { get; set; }

        [Required]
        public int BatchID { get; set; }

        public int RoomID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Address cannot be more than 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")
        [RegularExpression("[(]{1}[0-9]{3}[)]{1}[ ]{1}[0-9]{3}[-]{1}[0-9]{4}", ErrorMessage = "Format must be (###) ###-####")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(".{1,200}[@].{1,200}[.].{1,5}", ErrorMessage = "Email is too long, max 200 character on each side of @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [DataType(DataType.Text)]
        public string Gender { get; set; }

        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }

}
