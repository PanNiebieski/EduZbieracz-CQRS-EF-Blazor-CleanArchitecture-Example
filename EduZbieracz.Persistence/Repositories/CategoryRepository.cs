using EduZbieracz.Application;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduZbieracz.Persistence.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EduZbieraczContext dbContext) : base(dbContext)
        { }

        public async Task<List<Category>> GetCategoriesWithPost(SearchCategoryOptions searchCategory)
        {
            var allCategories = await _dbContext.Categories.Include(p => p.Posts).ToListAsync();

            if (searchCategory == SearchCategoryOptions.FirstBestAllTheTime)
            {
                allCategories.ForEach(p => p.Posts.Max(m => m.Rate));
                return allCategories;
            }
            else if (searchCategory == SearchCategoryOptions.FirstBestThisMonth)
            {
                DateTime d = DateTime.Now;

                allCategories = allCategories.Where(c =>
                c.Posts.Any(p => (p.Date.Month == d.Month && d.Year == p.Date.Year)))
                    .ToList();

                allCategories.ForEach(p => p.Posts.Max(m => m.Rate));
                return allCategories;
            }

            return allCategories;
        }
    }
}
