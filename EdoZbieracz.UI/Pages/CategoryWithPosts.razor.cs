using EdoZbieracz.UI.ClientServices;
using EdoZbieracz.UI.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.Pages
{
    public partial class CategoryWithPosts
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int SelectValue { get; set; }

        public ICollection<CategoryWithPostsBlazorVM> Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            SelectValue = 0;
            Categories = await CategoryService.GetAllCategoriesWithPosts(
                Services.SearchCategoryOptions._0);
        }

        private async Task OnChangeSearchOptionAsync(EventArgs args)
        {
            int searchoptions = SelectValue;
            Categories = null;

            Categories = await CategoryService.GetAllCategoriesWithPosts(
                (Services.SearchCategoryOptions)searchoptions);
        }

    }
}
