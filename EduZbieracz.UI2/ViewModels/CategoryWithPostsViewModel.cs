using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ViewModels
{
    public class CategoryWithPostsViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Display { get; set; }
        public ICollection<PostInsideCategoryViewModel> Posts { get; set; }
    }
}
