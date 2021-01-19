using EdoZbieracz.UI.ClientServices;
using EdoZbieracz.UI.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.Pages
{
    public partial class PostsList
    {
        [Inject]
        public IPostServices PostService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EditMode { get; set; }

        public ICollection<PostInListBlazorVM> Posts { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Posts = await PostService.GetAllPosts();
        }

        protected void AddNewPost()
        {
            NavigationManager.NavigateTo("/addpost");
        }
    }
}
