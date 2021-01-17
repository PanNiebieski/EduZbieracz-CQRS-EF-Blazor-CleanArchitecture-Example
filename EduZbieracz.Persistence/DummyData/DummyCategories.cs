using EduZbieracz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Persistence.EF.DummyData
{
    public class DummyCategories
    {
        public static List<Category> Get()
        {
            Category c1 = new Category()
            {
                CategoryId = 1,
                Name = "CSharp",
                DisplayName = "C#"
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
    }
}
