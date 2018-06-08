﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MockProject3.DA.Models
{
    ///<summary>The User model is used to contain all of the pertinent information about a user including name, location, room, address, email, gender, employee type, and batch they belong to. </summary>
    ///<remarks>    
    ///Each User object will have its own uniquely generated Guid Id and retain the primary key Guid that was generated for it in the previous database into UserId.
    ///</remarks>
    [Table("Users")]
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Name Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Location { get; set; }

        public Room Room { get; set; }
        public Address Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Type { get; set; }

        [Required]
        public Batch Batch { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime Deleted { get; set; }

        /// <summary>Default Constructor</summary>>
        /// <remarks>Sets all properties to empty, null, or impossible values that correspond 
        /// to invalid models that should be invalid if not replaced.</remarks>
        public User()
        {
            Id = Guid.Empty;
            UserId = Id = Guid.Empty;
            Location = null;
            Address = null;
            Email = null;
            Gender = null;
            Type = null;
            Batch = null;
            Created = DateTime.MinValue;
            Deleted = DateTime.MinValue;
        }

        /// <summary>Property validation</summary>>
        /// <remarks>Returns true if all properties are valid
        /// By default (through constructor), the model is invalid, properties to be filled in</remarks>
        public bool Validate()
        {
            if (Id == Guid.Empty) { return false; }
            if (UserId == Guid.Empty) { return false; }
            if (String.IsNullOrEmpty(Location)) { return false; }
            if (Address == null) { return false; }
            if (String.IsNullOrEmpty(Email)) { return false; }
            if (String.IsNullOrEmpty(Gender)) { return false; }
            if (String.IsNullOrEmpty(Type)) { return false; }
            if (Batch == null) { return false; }
            if (Created == DateTime.MinValue) { return false; }
            if (Deleted == DateTime.MinValue) { return false; }

            return true;
        }
    }

}
