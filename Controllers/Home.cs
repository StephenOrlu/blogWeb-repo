using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Assignment2.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Controllers
{
    public class Home : Controller
    {
        // GET: /<controller>/
        private Assignment2DataContext _Assignment2DataContext;


        public Home(Assignment2DataContext context)
        {
            _Assignment2DataContext = context;
        }


        public IActionResult Index()
        {

            return View(_Assignment2DataContext.BlogPosts.ToList());
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users users)
        {
            if (Request.Form["Role"] == "Admin")
            {
                users.RoleId = 2;
            }
            else
            {
                users.RoleId = 1;
            }

            var existing = (from u in _Assignment2DataContext.Users where (u.EmailAddress == users.EmailAddress) select u).FirstOrDefault();
            if (existing == null)
            {
                _Assignment2DataContext.Users.Add(users);
                _Assignment2DataContext.SaveChanges();
            }
            else
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AuthenticateUser()
        {
            String email = Request.Form["EmailAddress"];
            String pass = Request.Form["Password"];

            var user = (from u in _Assignment2DataContext.Users where (u.EmailAddress == email && u.Password == pass) select u).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetInt32("RoleId", user.RoleId);
                HttpContext.Session.SetString("UserName", user.FirstName + " " + user.LastName);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DisplayFullBlogPost(int id)
        {
            var blogPost = (from item in _Assignment2DataContext.BlogPosts where item.BlogPostId == id select item).FirstOrDefault();
            if (blogPost != null)
            {
                BlogPostViewModel model = new BlogPostViewModel();
                model.BlogPost = blogPost;
                model.Comment = new List<CommentViewModel>();
                
                var commentList = (from item in _Assignment2DataContext.Comments where item.BlogPostId == id select item).ToList();
                foreach (Comments com in commentList)
                {
                    CommentViewModel c = new CommentViewModel();
                    c.Comment = com;
                    var author = (from user in _Assignment2DataContext.Users where user.UserId == com.UserId select user).FirstOrDefault();
                    c.authorName = author.FirstName + " " + author.LastName;
                    //blogPost.Content.(c);
                }

                model.User = (from user in _Assignment2DataContext.Users where user.UserId == blogPost.UserId select user).FirstOrDefault();
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult DisplayFullBlogPost()
        {
            Comments comment = new Models.Comments();
            comment.BlogPostId = Convert.ToInt32(Request.Form["BlogPostId"]);
            comment.UserId = (int)HttpContext.Session.GetInt32("UserId");
            comment.Content = Request.Form["Content"];


            _Assignment2DataContext.Comments.Add(comment);
            _Assignment2DataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddBlogPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlogPost(BlogPosts posts)
        {
            posts.Posted = DateTime.Now;
            posts.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));

            _Assignment2DataContext.BlogPosts.Add(posts);
            _Assignment2DataContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditBlogPost(int id)
        {
            var edits = (from u in _Assignment2DataContext.BlogPosts where u.BlogPostId == id select u).FirstOrDefault();
            return View(edits);
        }

        [HttpPost]
        public IActionResult EditBlogPost(BlogPosts posts)
        {
            var id = Convert.ToInt32(Request.Form["BlogPostId"]);
            var postsEdit = (from u in _Assignment2DataContext.BlogPosts where u.BlogPostId == posts.BlogPostId select u).FirstOrDefault();
            if (postsEdit == null)
            {
                return RedirectToAction("Index");
            }

            postsEdit.Title = posts.Title;
            postsEdit.Content = posts.Content;
            _Assignment2DataContext.Entry(postsEdit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Assignment2DataContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteBlogPost(int id)
        {
            var deleteBlogs = (from u in _Assignment2DataContext.BlogPosts where u.BlogPostId == id select u).FirstOrDefault();

            _Assignment2DataContext.BlogPosts.Remove(deleteBlogs);
            _Assignment2DataContext.Entry(deleteBlogs).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _Assignment2DataContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}