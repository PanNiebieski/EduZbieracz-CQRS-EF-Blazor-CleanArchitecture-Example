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
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryWithPostsViewModel>> GetAllCategoriesWithPosts
            (SearchCategoryOptions searchCategoryOptions);

        Task<ResponseFromApi<int>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
