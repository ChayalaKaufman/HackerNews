using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HackerNewsLibrary
{
    public class HackerNewsAPI
    {
        public List<int> GetTopTwentyIds()
        {
            var client = new HttpClient();
            string url = "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
            string json = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<List<int>>(json);
            return result;
        }

        public News GetStoryById(int id)
        {
            var client = new HttpClient();
            string url = $"https://hacker-news.firebaseio.com/v0/item/{id}.json?print=pretty";
            string json = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<News>(json);
            return result;
        }
    }
}
