using EdoZbieracz.UI.ClientServices;
using EdoZbieracz.UI.Components;
using EdoZbieracz.UI.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.Pages
{
    public partial class Webinars
    {
        [Inject]
        public IWebinarService WebinarService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EditMode { get; set; }

        public string SelectedMonth { get; set; }
        public string SelectedYear { get; set; }

        public List<string> MonthList { get; set; } = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public List<string> YearList { get; set; } = new List<string>() { "2019", "2020", "2021" };

        private int? pageNumber = 1;

        private PaginatedList<WebinarForDateListBlazorVM> paginatedList
    = new PaginatedList<WebinarForDateListBlazorVM>();

        private IEnumerable<WebinarForDateListBlazorVM> webinarsList;

        protected async Task GetWebinars()
        {
            WebinarPagedForDateBlazorVM pagedata;

            if (!string.IsNullOrWhiteSpace(SelectedYear) && !string.IsNullOrWhiteSpace(SelectedMonth))
            {
                DateTime dt = new DateTime(int.Parse(SelectedYear), int.Parse(SelectedMonth), 1);
                pagedata =
                   await WebinarService.GetPagedWebinarForDate(Services.SearchOptionsWebinars._3, dt, pageNumber.Value, 5);
            }
            else if (!string.IsNullOrWhiteSpace(SelectedYear))
            {
                DateTime dt = new DateTime(int.Parse(SelectedYear), 11, 1);
                pagedata =
                   await WebinarService.GetPagedWebinarForDate(Services.SearchOptionsWebinars._2, dt, pageNumber.Value, 5);
            }
            else if (!string.IsNullOrWhiteSpace(SelectedMonth))
            {
                DateTime dt = new DateTime(2020, int.Parse(SelectedMonth), 1);
                pagedata =
                   await WebinarService.GetPagedWebinarForDate(Services.SearchOptionsWebinars._3, dt, pageNumber.Value, 5);
            }
            else
            {
                pagedata =
                await WebinarService.GetPagedWebinarForDate(Services.SearchOptionsWebinars._1, null, pageNumber.Value, 5);

            }


            var g = pagedata.Webinars.ToList();
            paginatedList = new PaginatedList<WebinarForDateListBlazorVM>(g, pagedata.AllCount, pageNumber.Value, 5);
            webinarsList = paginatedList.Items;

            StateHasChanged();
        }

        public async void PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
            {
                return;
            }
            pageNumber = newPageNumber;
            await GetWebinars();
            StateHasChanged();
        }
    }
}
