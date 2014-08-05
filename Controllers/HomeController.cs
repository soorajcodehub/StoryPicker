using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using StoryPicker.Core;

namespace StoryPicker.Controllers
{
    public class HomeController : Controller
    {
        StoryPostService _storyPostService = new StoryPostService();
        public ActionResult Index()
        {
            ViewBag.Message = "Stories";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new StoryPost());
        }

        [HttpPost]
        public ActionResult Create(StoryPost storyPost)
        {
            if (ModelState.IsValid)
            {
                storyPost.Author = User.Identity.Name;
                storyPost.Date = DateTime.Now;
                _storyPostService.createStoryPost(storyPost);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ViewStories()
        {
            return View(_storyPostService.getStoryPosts());
        }

        public ActionResult ViewStoryTitles()
        {
            return View(_storyPostService.getStoryPostTitles());
        }
    }
}
