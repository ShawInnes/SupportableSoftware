using System;

namespace SwaggerDemo.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public DateTimeOffset Published { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
    }
}