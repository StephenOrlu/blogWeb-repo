﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Models
{
    public class Roles
    {
        [Key]
        public int RoleId
        {
            get;
            set;

        }


        [Required]
        [StringLength(1000)]
        public string Name
        {
            get;
            set;
        }
    }
}


