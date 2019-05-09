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
            IEnumerable<int> ids = api.GetTopTwentyIds();
            List<News> Stories = new List<News>();
            int i = 1;
            foreach(int id in ids)
            {
                if(i <= 20)
                {
                    Stories.Add(api.GetStoryById(id));
                    i++;
                }
                else
                {
                    break;
                }
            }
            return View(Stories);
        }
    }
}
