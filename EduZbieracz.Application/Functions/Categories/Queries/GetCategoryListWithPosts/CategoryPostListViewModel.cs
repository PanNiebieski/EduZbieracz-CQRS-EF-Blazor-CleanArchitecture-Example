using EduZbieracz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Categories.Queries.GetCategoryListWithPosts
{
    public class CategoryPostListViewModel
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public ICollection<CategoryPostDto> Posts { get; set; }
    }
}
