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
    public class Photos
    {
        [Key]
        public int PhotoId
        {
            get;
            set;

        }

        [ForeignKey("BlogPostId")]
        public int BlogPostId
        {
            get;
            set;

        }

        [Required]
        [StringLength(255)]
        public string Filename
        {
            get;
            set;
        }

        [Required]
        [StringLength(2048)]
        public string Url
        {
            get;
            set;
        }

    }
}