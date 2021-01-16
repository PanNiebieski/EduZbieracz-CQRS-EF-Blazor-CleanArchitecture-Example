using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        //[Required]
        //[StringLenght(80)]
        public string Title { get; set; }

        //[StringLenght(40)]
        public string Author { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string ImageUrl { get; set; }
        public string Url { get; set; }

        //[Range(0, 100)]
        public int Rate { get; set; }
    }
}
