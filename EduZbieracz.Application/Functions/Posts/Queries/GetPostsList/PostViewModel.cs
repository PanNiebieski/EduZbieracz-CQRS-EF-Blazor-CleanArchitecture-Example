using System;

namespace EduZbieracz.Application.Functions.Posts
{
    public class PostInListViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}