using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Categories.Queries.GetCategoryListWithPosts
{
    public class CategoryPostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public int Rate { get; set; }

        public int CategoryId { get; set; }
    }
}
