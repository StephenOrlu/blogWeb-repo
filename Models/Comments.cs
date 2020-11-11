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
    public class Comments
    {
        [Key]
        public int CommentId
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

        [ForeignKey("UserId")]
        public int UserId
        {
            get;
            set;

        }

        [Required]
        [StringLength(2000)]
        public string Content
        {
            get;
            set;
        }
        [Required]
        [Range(1,5)]
        public int Rating
        {
            get;
            set;
        }

    }
}