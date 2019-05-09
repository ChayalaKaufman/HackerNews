using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackerNews.Models;
using HackerNewsLibrary;

namespace HackerNews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HackerNewsAPI api = new HackerNewsAPI();
            List<int> ids = api.GetTopTwentyIds();
            List<News> Stories = new List<News>();

            for(int i = 0; i < 20; i++)
            {
                Stories.Add(api.GetStoryById(ids[i]));
            }
            return View(Stories);
        }
    }
}
