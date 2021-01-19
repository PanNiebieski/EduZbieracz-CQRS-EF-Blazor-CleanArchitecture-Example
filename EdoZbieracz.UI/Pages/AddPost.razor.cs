using EdoZbieracz.UI.ClientServices;
using EdoZbieracz.UI.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.Pages
{
    public partial class AddPost
    {
        [Inject]
        public IPostServices PostService { get; set; }

        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PostDetailBlazorVM PostDetailViewModel { get; set; }
            = new PostDetailBlazorVM() { Date = DateTime.Now };

        public ObservableCollection<CategoryBlazorVM> Categories { get; set; }
            = new ObservableCollection<CategoryBlazorVM>();

        public string Message { get; set; }
        public string SelectedCategoryId { get; set; }

        [Parameter]
        public string PostId { get; set; }
        private int SelectedPostId = 0;

        protected override async Task OnInitializedAsync()
        {
            if (int.TryParse(PostId, out SelectedPostId))
            {
                PostDetailViewModel = await PostService.GetPostById(SelectedPostId);
                SelectedCategoryId = PostDetailViewModel.CategoryId.ToString();
            }

            var list = await CategoryService.GetAllCategories();
            Categories = new ObservableCollection<CategoryBlazorVM>(list);
            SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            PostDetailViewModel.CategoryId = int.Parse(SelectedCategoryId);
            ResponseFromApi<int> response;

            if (SelectedPostId == 0)
            {
                response = await PostService.CreatePost(PostDetailViewModel);
            }
            else
            {
                response = await PostService.UpdatePost(PostDetailViewModel);
            }
            HandleResponse(response);

        }

        protected async Task DeletePost()
        {
            var response = await PostService.DeletePost(SelectedPostId);
            HandleResponse(response);
        }

        protected void NavigateToPosts()
        {
            NavigationManager.NavigateTo("/postlist");
        }

        private void HandleResponse(ResponseFromApi<int> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/postlist");
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
