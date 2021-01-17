using EduZbieracz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Persistence.EF.DummyData
{
    public static class DummyPosts
    {
        public static List<Post> Get()
        {
            var cat = DummyCategories.Get();

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
    }
}
