using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ViewModels
{
    public class PostInsideCategoryViewModel
    {
        public int PostId { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }

        public string ImageUrl { get; set; }
        public string Url { get; set; }

        [Range(0, 100)]
        public int Rate { get; set; }
    }
}
