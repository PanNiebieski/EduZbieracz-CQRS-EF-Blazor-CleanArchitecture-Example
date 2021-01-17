using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Webinars.Queries.GetWebinarListByDate
{
    public class WebinarsByDateViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string FacebookEventUrl { get; set; }

        public string SlidesUrl { get; set; }

        public string WatchFacebookLink { get; set; }

        public string WatchYoutubeLink { get; set; }

        public DateTime Date { get; set; }
    }
}
