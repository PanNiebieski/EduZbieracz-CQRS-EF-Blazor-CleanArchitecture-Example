using EdoZbieracz.UI.Services;
using EdoZbieracz.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ClientServices
{
    public interface ICategoryService
    {
        Task<List<CategoryBlazorVM>> GetAllCategories();
        Task<List<CategoryWithPostsBlazorVM>> GetAllCategoriesWithPosts
            (SearchCategoryOptions searchCategoryOptions);

        Task<ResponseFromApi<int>> CreateCategory(CategoryBlazorVM categoryViewModel);
    }
}
