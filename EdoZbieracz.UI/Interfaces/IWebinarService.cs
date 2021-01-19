using EdoZbieracz.UI.Services;
using EdoZbieracz.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ClientServices
{
    public interface IWebinarService
    {
        Task<WebinarPagedForDateBlazorVM> GetPagedWebinarForDate(SearchOptionsWebinars s, DateTime? date, int page, int pageSize);

        Task<ResponseFromApi<int>> CreateWebinar(WebinarBlazorVM webinarDetailViewModel);

        Task<WebinarBlazorVM> GetWebinarById(int id);

        Task<ResponseFromApi<int>> UpdateWebinar(WebinarBlazorVM webinarDetailViewModel);
        Task<ResponseFromApi<int>> DeleteWebinar(int id);
    }
}
