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

        public ICollection<CategoryWithPostsViewModel> Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetAllCategoriesWithPosts(
                Services.SearchCategoryOptions._0);
        }

        //protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
        //{
        //    if ((bool)args.Value)
        //    {
        //        Categories = await CategoryDataService.GetAllCategoriesWithEvents(true);
        //    }
        //    else
        //    {
        //        Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
        //    }
        //}
    }
}
