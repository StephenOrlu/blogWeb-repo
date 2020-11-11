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
    public class BlogPosts
    {
        [Key]
        public int BlogPostId
        {
            get;
            set;

        }

        [ForeignKey("UserId")]
        public int UserId
        {
            get;
            set;

        }
        [Required]
        [StringLength(1000)]
        public string Title
        {
            get;
            set;
        }

        [Required]
        [StringLength(400)]
        public string ShortDescription
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string Content
        {
            get;
            set;
        }

       /* [Required]
        [StringLength(1000)]
        public string Comment
        {
            get;
            set;
        }*/

        [Required]
        [DataType(DataType.Date)]
        public DateTime Posted
        {
            get;
            set;
        }

        [Required]
        public bool IsAvailable
        {
            get;
            set;
        }
    }
}