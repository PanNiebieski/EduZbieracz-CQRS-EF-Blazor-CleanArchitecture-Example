using EduZbieracz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Persistence.EF.DummyData
{
    public class DummyWebinars
    {
        public static List<Webinar> Get()
        {
            List<Webinar> w = new List<Webinar>();

            var w1 = new Webinar()
            {
                Title = "Aplikacja C# od Zera Architektura, CQRS, Dobre praktyki",
                AlreadyHappend = false,
                Date = DateTime.Now.AddDays(10),
                Description = @"Ustalenie architektury nie jest prostym zadaniem. Każda decyzja może mieć wielkie komplikacje potem.",
                FacebookEventUrl = "https://www.facebook.com/events/407358067213893/",
                Id = 1,
                ImageUrl = "https://cezarywalenciuk.pl/posts/fileswebinars/17_apliacjacsharpodzeraarchitekturacqrs.jpg",
                SlidesUrl = "",
                WatchFacebookLink = "",
                WatchYoutubeLink = "",
            };
            w.Add(w1);

            var w2 = new Webinar()
            {
                Title = "Kubernetes i Docker : Wytłumacz mi i pokaż",
                AlreadyHappend = false,
                Date = DateTime.Now.AddDays(-40),
                Description = @"Kontenery są tutaj. Kubernetes jest de facto platformą do ich uruchamiania i zarządzania.",
                FacebookEventUrl = "https://www.facebook.com/events/407358067213893/",
                Id = 2,
                ImageUrl = "https://cezarywalenciuk.pl/posts/fileswebinars/17_apliacjacsharpodzeraarchitekturacqrs.jpg",
                SlidesUrl = "https://panniebieski.github.io/webinar-Kubernetes-Docker-Wytlumacz-mi-i-pokaz/",
                WatchFacebookLink = "https://www.facebook.com/watch/live/?v=2775230679405348&ref=watch_permalink",
                WatchYoutubeLink = "https://www.youtube.com/watch?v=7g00wOg9Jto",
            };
            w.Add(w2);


            var w3 = new Webinar()
            {
                Title = "C# 9, Rekordy i duże zmiany w .NET 5",
                AlreadyHappend = false,
                Date = DateTime.Now.AddDays(-60),
                Description = @"Jak utworzyć projekt w .NET 5?",
                FacebookEventUrl = "https://www.facebook.com/events/407358067213893/",
                Id = 3,
                ImageUrl = "https://cezarywalenciuk.pl/posts/fileswebinars/15_csharpirekordy.jpg",
                SlidesUrl = "https://panniebieski.github.io/webinar_CSharp9-Rekordy-i-duze-zamiany-w-net-5/",
                WatchFacebookLink = "https://www.facebook.com/watch/live/?v=2835303250091399&ref=watch_permalink",
                WatchYoutubeLink = "https://www.youtube.com/watch?v=ATbLEyd_1Kg",
            };
            w.Add(w3);

            var w4 = new Webinar()
            {
                Title = "Szybki Trening Sql Server 2",
                AlreadyHappend = false,
                Date = DateTime.Now.AddDays(-70),
                Description = @"Czasami jedyne czego potrzebujemy to dobrego przykładu.",
                FacebookEventUrl = "https://www.facebook.com/events/407358067213893/",
                Id = 4,
                ImageUrl = "https://cezarywalenciuk.pl/posts/fileswebinars/15_csharpirekordy.jpg",
                SlidesUrl = "https://panniebieski.github.io/webinar_CSharp9-Rekordy-i-duze-zamiany-w-net-5/",
                WatchFacebookLink = "https://www.facebook.com/watch/live/?v=2835303250091399&ref=watch_permalink",
                WatchYoutubeLink = "https://www.youtube.com/watch?v=ATbLEyd_1Kg",
            };
            w.Add(w4);

            var w5 = new Webinar()
            {
                Title = "Pytania rekrutacyjne czyli dalsza kariera",
                AlreadyHappend = false,
                Date = DateTime.Now.AddDays(-90),
                Description = @"Jak wygląda szukanie pracy jako programista w 2020 roku? Czy jest lepiej, czy jest gorzej?",
                FacebookEventUrl = "https://www.facebook.com/events/407358067213893/",
                Id = 5,
                ImageUrl = "https://cezarywalenciuk.pl/posts/fileswebinars/15_csharpirekordy.jpg",
                SlidesUrl = "https://panniebieski.github.io/webinar_CSharp9-Rekordy-i-duze-zamiany-w-net-5/",
                WatchFacebookLink = "https://www.facebook.com/watch/live/?v=2835303250091399&ref=watch_permalink",
                WatchYoutubeLink = "https://www.youtube.com/watch?v=ATbLEyd_1Kg",
            };
            w.Add(w5);

            return w;
        }
    }
}
