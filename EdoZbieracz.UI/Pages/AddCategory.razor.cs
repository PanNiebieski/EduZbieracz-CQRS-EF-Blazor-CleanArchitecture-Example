using EdoZbieracz.UI.ClientServices;
using EdoZbieracz.UI.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.Pages
{
    public partial class AddCategory
    {
        [Inject]
        public ICategoryService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CategoryBlazorVM CategoryViewModel { get; set; }
        public string Message { get; set; }

        protected override void OnInitialized()
        {
            CategoryViewModel = new CategoryBlazorVM();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await CategoryDataService.CreateCategory(CategoryViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ResponseFromApi<int> response)
        {
            if (response.Success)
            {
                Message = "Category added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
