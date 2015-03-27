using System;
using System.Collections.Generic;
using System.Web.Http;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    public class NewsController : ApiController
    {
        public IEnumerable<NewsItem> Get()
        {
            return new List<NewsItem>
            {
                new NewsItem
                {
                    Id = 1,
                    Title = "Hello World #1",
                    Content = "Lorem Ipsum...",
                    Published = DateTimeOffset.UtcNow
                },
                new NewsItem
                {
                    Id = 2,
                    Title = "Hello World #2",
                    Content = "Lorem Ipsum...",
                    Published = DateTimeOffset.UtcNow
                }
            };
        }

        public NewsItem Get(int id)
        {
            return new NewsItem {Id = id};
        }
    }
}