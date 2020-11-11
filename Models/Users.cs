using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Models
{
    public class Users
    {
        [Key]
        public int UserId
        {
            get;
            set;

        }

        [ForeignKey("RoleId")]
        public int RoleId
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string LastName
        {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string EmailAddress
        {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string Password
        {
            get;
            set;
        }

        [Required]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string City
        {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string Address
        {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string PostalCode
        {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string Country
        {
            get;
            set;
        }
    }
}