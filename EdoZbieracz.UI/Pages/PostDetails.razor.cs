using EdoZbieracz.UI.ClientServices;
using EdoZbieracz.UI.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.Pages
{
    public partial class PostDetails
    {
        [Inject]
        public IPostServices PostService { get; set; }

        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PostDetailBlazorVM PostDetailViewModel { get; set; } = new PostDetailBlazorVM();

        [Parameter]
        public string PostId { get; set; }
        private int SelectedPostId = 0;

        protected override async Task OnInitializedAsync()
        {
            if (int.TryParse(PostId, out SelectedPostId))
            {
                PostDetailViewModel = await PostService.GetPostById(SelectedPostId);
            }

        }

        protected void NavigateToPosts()
        {
            NavigationManager.NavigateTo("/postlist");
        }

    }
}
