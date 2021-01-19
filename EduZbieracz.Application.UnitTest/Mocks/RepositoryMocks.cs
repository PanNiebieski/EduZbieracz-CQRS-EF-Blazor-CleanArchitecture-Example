using EduZbieracz.Application.Common;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduZbieracz.Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = GetCategories();

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var cat = categories.FirstOrDefault(c => c.CategoryId == id);
                return cat;
            });

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            mockCategoryRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Category>())).Callback
                <Category>((entity) => categories.Remove(entity));

            mockCategoryRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Category>())).Callback
                <Category>((entity) => { categories.Remove(entity); categories.Add(entity); });

            var categorieswithpost = GetCategoriesWithPosts();
            mockCategoryRepository.Setup(repo => repo.GetCategoriesWithPost
                (It.IsAny<SearchCategoryOptions>()))
                .ReturnsAsync(categorieswithpost);

            return mockCategoryRepository;
        }


        private static List<Category> GetCategories()
        {
            Category c1 = new Category()
            {
                CategoryId = 1,
                Name = "CSharp",
                DisplayName = "C#",
            };

            Category c2 = new Category()
            {
                CategoryId = 2,
                Name = "aspnet",
                DisplayName = "ASP.NET"
            };

            Category c3 = new Category()
            {
                CategoryId = 3,
                Name = "triki-z-windows",
                DisplayName = "Triki z Windows"
            };

            Category c4 = new Category()
            {
                CategoryId = 4,
                Name = "docker",
                DisplayName = "Docker"
            };

            Category c5 = new Category()
            {
                CategoryId = 5,
                Name = "filozofia",
                DisplayName = "Filozofia"
            };


            List<Category> p = new List<Category>();
            p.Add(c1); p.Add(c3);
            p.Add(c2); p.Add(c4);
            p.Add(c5);

            return p;

        }

        private static List<Category> GetCategoriesWithPosts()
        {
            var posts = GetPosts();
            Category c1 = new Category()
            {
                CategoryId = 1,
                Name = "CSharp",
                DisplayName = "C#",
                Posts = posts.Where(p => p.CategoryId == 1).ToList()
            };

            Category c2 = new Category()
            {
                CategoryId = 2,
                Name = "aspnet",
                DisplayName = "ASP.NET",
                Posts = posts.Where(p => p.CategoryId == 2).ToList()
            };

            Category c3 = new Category()
            {
                CategoryId = 3,
                Name = "triki-z-windows",
                DisplayName = "Triki z Windows",
                Posts = posts.Where(p => p.CategoryId == 3).ToList()
            };

            Category c4 = new Category()
            {
                CategoryId = 4,
                Name = "docker",
                DisplayName = "Docker",
                Posts = posts.Where(p => p.CategoryId == 4).ToList()
            };

            Category c5 = new Category()
            {
                CategoryId = 5,
                Name = "filozofia",
                DisplayName = "Filozofia",
                Posts = posts.Where(p => p.CategoryId == 5).ToList()
            };


            List<Category> p = new List<Category>();
            p.Add(c1); p.Add(c3);
            p.Add(c2); p.Add(c4);
            p.Add(c5);

            return p;

        }

        public static Mock<IPostRepository> GetPostRepository()
        {
            var posts = GetPosts();
            var mockpostRepository = new Mock<IPostRepository>();

            mockpostRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(posts);

            mockpostRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var pos = posts.FirstOrDefault(c => c.PostId == id);
                return pos;
            });

            mockpostRepository.Setup(repo => repo.AddAsync(It.IsAny<Post>())).ReturnsAsync(
            (Post post) =>
            {
                posts.Add(post);
                return post;
            });

            mockpostRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Post>())).Callback
                <Post>((entity) => posts.Remove(entity));

            mockpostRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Post>())).Callback
                <Post>((entity) => { posts.Remove(entity); posts.Add(entity); });

            mockpostRepository.Setup(repo => repo.IsNameAndAuthorAlreadyExist
                (It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((string title, string author) =>
                {
                    var matches = posts.
                    Any(a => a.Title.Equals(title) && a.Author.Equals(author));
                    return matches;
                });

            return mockpostRepository;
        }

        public static List<Post> GetPosts()
        {
            var cat = GetCategories();

            Post p1 = new Post()
            {
                Author = "Damian",
                Date = DateTime.Now.AddMonths(-6),
                Description = @"Nasze aplikacje ASP.NET CORE coraz częściej są tylko aplikacją REST. To oczywiście wymaga Walidacji po stronie klienta i po stronie serwera
Jak taką walidację jak najszybciej zrobić.Może przecież sam napisać takie warunki,
                ale przy dużej ilości klas,
                które występują jako parametry mija się to z celem.

Możesz też skorzystać z atrybutów i oznaczyć reguły do każdej właściwości.",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 2,
                Rate = 8,
                Category = cat[1],
                CategoryId = cat[1].CategoryId,
                Title = "Walidacja z FluentValidation w ASP.NET Core + Swagger",
                Url = "https://cezarywalenciuk.pl/blog/programing/walidacja-z-fluentvalidation-waspnet-core--swagger"
            };

            Post p2 = new Post()
            {
                Author = "Damian",
                Date = DateTime.Now.AddMonths(-6),
                Description = @"Programiści codziennie tworzą jakąś aplikację sieciową typu REST. Teraz nastaje pytanie, jak najlepiej zrozumieć jak dane API działa. Do tego mamy dokumentacje, ale jeśli pracujesz w szybkich, zamkniętych projektach to takiej dokumentacji może nie być.",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 3,
                Category = cat[1],
                CategoryId = cat[1].CategoryId,
                Rate = 7,
                Title = "Swagger UI : Dokumentowanie API w ASP.NET CORE",
                Url = "https://cezarywalenciuk.pl/blog/programing/swagger-ui--dokumentowanie-api-w-aspnet-core"
            };

            Post p3 = new Post()
            {
                Author = "Stefan",
                Date = DateTime.Now.AddMonths(-12),
                Description = @"W pod koniec roku 2017 zacząłem ćwiczyć. Proste ćwiczenia rzeczywiście robią różnice, gdy masz siedzący tryb życia. A co z bieganiem ?
Pamiętam jak pierwszy raz na bieżni nie byłem w stanie wytrzymać 5 minut normalnego spaceru. Powoli z tygodnia na dzień zacząłem sobie stawiać wyższe progi i tak odkryłem, że o ile jest to na początku bolesne to jak twoje ciało da Ci te endorfiny to już...aż chce się biegać więcej. ",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 4,
                Category = cat[4],
                CategoryId = cat[4].CategoryId,
                Rate = 5,
                Title = "Bieganie jak się do tego zmotywować : Zdrowie Programisty",
                Url = "https://cezarywalenciuk.pl/blog/programing/bieganie-jak-sie-do-tego-zmotywowac--zdrowie-programisty"
            };

            Post p4 = new Post()
            {
                Author = "Damian",
                Date = DateTime.Now.AddMonths(-12),
                Description = @"Logowanie działania aplikacji. Jak wiedzieć w końcu, gdy coś nie działa. Mój blog jest napisany w C# i działa po ASP.NET CORE. Jak to jednak bywa z napisaną przez siebie aplikacją pojawiają się błędy więc do bloga dodałem mechanizm logowania błędów. W taki sposób znalazłem wiele dziwnych przypadków uszkodzonych wpisów w formacie XML, które rozwalały Parser. Znalazłem też złe zbudowane przez ze mnie lista kursów. ",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 4,
                Category = cat[1],
                CategoryId = cat[1].CategoryId,
                Rate = 5,
                Title = "NLog z ASP.NET Core : Logowanie błędów w aplikacji",
                Url = "https://cezarywalenciuk.pl/blog/programing/nlog-z-aspnet-core--logowanie-b%C5%82edow-w-aplikacji"
            };

            Post p5 = new Post()
            {
                Author = "Damian",
                Date = DateTime.Now.AddMonths(-12),
                Description = @"Logowanie działania aplikacji. Jak wiedzieć w końcu, gdy coś nie działa. Mój blog jest napisany w C# i działa po ASP.NET CORE. Jak to jednak bywa z napisaną przez siebie aplikacją pojawiają się błędy więc do bloga dodałem mechanizm logowania błędów. W taki sposób znalazłem wiele dziwnych przypadków uszkodzonych wpisów w formacie XML, które rozwalały Parser. Znalazłem też złe zbudowane przez ze mnie lista kursów. ",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 5,
                Category = cat[1],
                CategoryId = cat[1].CategoryId,
                Rate = 5,
                Title = "NLog z ASP.NET Core : Logowanie błędów w aplikacji",
                Url = "https://cezarywalenciuk.pl/blog/programing/nlog-z-aspnet-core--logowanie-b%C5%82edow-w-aplikacji"
            };

            Post p6 = new Post()
            {
                Author = "Damian",
                Date = DateTime.Now.AddMonths(-8),
                Description = @"W tym  artykule zobaczymy jak zintegrować AutoMapper  z ASP.NET CORE dla .NET 5, chociaż bądźmy szczerzy możesz skorzystać z tej biblioteki w każdym projekcie w C#.",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 6,
                Category = cat[1],
                CategoryId = cat[1].CategoryId,
                Rate = 9,
                Title = "AutoMapper z ASP.NET CORE czyli mapowanie klas",
                Url = "https://cezarywalenciuk.pl/blog/programing/automapper-z-aspnet-core"
            };

            Post p7 = new Post()
            {
                Author = "Adrian",
                Date = DateTime.Now.AddMonths(-14),
                Description = @"Nagrywanie Gif - ów ? Robienie obrazków na bloga ? Jak to robić jeszcze szybciej ? ",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 7,
                Category = cat[2],
                CategoryId = cat[2].CategoryId,
                Rate = 4,
                Title = "ShareX : Lepszy PrintScreen oraz robienie Gif-ów twojego pulpitu?",
                Url = "https://cezarywalenciuk.pl/blog/programing/sharex-lepszy-printscreen-oraz-robienie-gif-ow"
            };

            Post p8 = new Post()
            {
                Author = "Adrian",
                Date = DateTime.Now.AddMonths(-15),
                Description = @"Jak jeszcze lepiej ulepszyć system operacyjny Windows.

Czy być może programy tobie, które za chwilę to śmieci, które nie będą ci potrzebne?

Zazwyczaj w tym cyklu pokazuje programy, z które moim bardzo zmieniają przepływ mojej pracy.",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 8,
                Category = cat[2],
                CategoryId = cat[2].CategoryId,
                Rate = 5,
                Title = "QuickLook, TeraCopy, ProcessExplorer czy to potrzebne jest ?",
                Url = "https://cezarywalenciuk.pl/blog/programing/sharex-lepszy-printscreen-oraz-robienie-gif-ow"
            };

            Post p9 = new Post()
            {
                Author = "Adrian",
                Date = DateTime.Now.AddMonths(-15),
                Description = @"Jak jeszcze lepiej ulepszyć system operacyjny Windows.

Czy być może programy tobie, które za chwilę to śmieci, które nie będą ci potrzebne?

Zazwyczaj w tym cyklu pokazuje programy, z które moim bardzo zmieniają przepływ mojej pracy.",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                PostId = 10,
                Category = cat[1],
                CategoryId = cat[1].CategoryId,
                Rate = 9,
                Title = "Docker File dla Go, ASP.NET Core, .NET 5, Java Spring, NodeJS, Python",
                Url = "https://cezarywalenciuk.pl/blog/programing/docker-file-dla-go-aspnet-core-net-5-java-spring-nodejs-python"
            };

            List<Post> p = new List<Post>();
            p.Add(p1); p.Add(p3);
            p.Add(p2); p.Add(p4);
            p.Add(p5); p.Add(p6);
            p.Add(p8); p.Add(p7);
            p.Add(p9);

            return p;
        }

        public static Mock<IWebinaryRepository> GetWebinarRepository()
        {
            var webinars = GetWebinars();
            var mockWebinarRepository = new Mock<IWebinaryRepository>();

            mockWebinarRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(webinars);

            mockWebinarRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var pos = webinars.FirstOrDefault(c => c.Id == id);
                return pos;
            });

            mockWebinarRepository.Setup(repo => repo.AddAsync(It.IsAny<Webinar>())).ReturnsAsync(
            (Webinar webinar) =>
            {
                webinars.Add(webinar);
                return webinar;
            });

            mockWebinarRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Webinar>())).Callback
                <Webinar>((entity) => webinars.Remove(entity));

            mockWebinarRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Webinar>())).Callback
                <Webinar>((entity) => { webinars.Remove(entity); webinars.Add(entity); });

            mockWebinarRepository.Setup(repo => repo.GetPagedWebinarsForDate
            (It.IsAny<SearchOptionsWebinars>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime?>()))
            .ReturnsAsync((DateTime date, int page, int pageSize) =>
            {
                var matches = webinars.Where(x => x.Date.Month == date.Month && x.Date.Year == date.Year)
                .Skip((page - 1) * pageSize).Take(pageSize).ToList();

                return matches;
            });

            mockWebinarRepository.Setup(repo => repo.GetTotalCountOfWebinarsForDate
            (It.IsAny<SearchOptionsWebinars>(), It.IsAny<DateTime?>()))
            .ReturnsAsync((DateTime date) =>
            {
                var matches = webinars.Count
                (x => x.Date.Month == date.Month && x.Date.Year == date.Year);

                return matches;
            });

            return mockWebinarRepository;
        }

        public static List<Webinar> GetWebinars()
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
                Id = 4,
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
