using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.Pages
{
    public partial class AdminOptions
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected void NavigateToAddPost()
        {
            NavigationManager.NavigateTo("/AddPost");
        }

        protected void NavigateToAddWebinar()
        {
            NavigationManager.NavigateTo("/AddWebinar");
        }

        protected void NavigateToAddCategory()
        {
            NavigationManager.NavigateTo("/AddCategory");
        }

        protected void NavigateToUpdateWebinars()
        {
            NavigationManager.NavigateTo("/webinars/editmode/yes");

        }
        protected void NavigateToUpdatePosts()
        {
            NavigationManager.NavigateTo("/postlist/editmode/yes");
        }
    }
}
