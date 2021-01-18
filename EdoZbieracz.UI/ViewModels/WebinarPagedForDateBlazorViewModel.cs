using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ViewModels
{
    public class WebinarPagedForDateBlazorViewModel
    {
        public int PageSize { get; set; }

        public int Page { get; set; }

        public int AllCount { get; set; }

        public ICollection<WebinarForDateListBlazorViewModel> Webinars { get; set; }
    }
}
