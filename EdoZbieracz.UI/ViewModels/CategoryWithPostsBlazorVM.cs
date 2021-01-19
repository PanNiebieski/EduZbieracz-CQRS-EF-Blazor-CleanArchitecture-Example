using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ViewModels
{
    public class CategoryWithPostsBlazorVM
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ICollection<PostInsideCategoryBlazorVM> Posts { get; set; }
    }
}
