using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.ViewModels
{
    public class BlogPostViewModel
    {
        public Models.BlogPosts BlogPost { get; set; }
        public List<CommentViewModel> Comment { get; set; }
        public Models.Users User { get; set; }
    }

    public class CommentViewModel
    {
        public Comments Comment { get; set; }
        public string authorName { get; set; }
    }
}