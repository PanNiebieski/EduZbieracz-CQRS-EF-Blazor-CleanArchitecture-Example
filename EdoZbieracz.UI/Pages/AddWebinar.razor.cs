using EdoZbieracz.UI.ClientServices;
using EdoZbieracz.UI.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.Pages
{
    public partial class AddWebinar
    {
        [Inject]
        public IWebinarService WebinarService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public WebinarBlazorVM WebinarViewModel { get; set; }
            = new WebinarBlazorVM() { Date = DateTime.Now };

        [Parameter]
        public string WebinarId { get; set; }
        private int SelectedWebinarId = 0;

        public string Message { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (int.TryParse(WebinarId, out SelectedWebinarId))
            {
                WebinarViewModel = await WebinarService.GetWebinarById(SelectedWebinarId);
            }

        }

        protected async Task HandleValidSubmit()
        {
            ResponseFromApi<int> response;

            if (SelectedWebinarId == 0)
            {
                response = await WebinarService.CreateWebinar(WebinarViewModel);
            }
            else
            {
                response = await WebinarService.UpdateWebinar(WebinarViewModel);
            }
            HandleResponse(response);

        }

        protected void NavigateToWebinar()
        {
            NavigationManager.NavigateTo("/webinars");
        }

        private void HandleResponse(ResponseFromApi<int> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/webinars");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }

        protected async Task DeleteWebinar()
        {
            var response = await WebinarService.DeleteWebinar(SelectedWebinarId);
            HandleResponse(response);
        }
    }
}
