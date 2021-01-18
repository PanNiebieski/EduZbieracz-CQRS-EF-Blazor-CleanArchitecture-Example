using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Persistence.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Persistence.EF
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddEduZbieraczPersistenceEFServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EduZbieraczContext>(options =>
                options.UseSqlServer(configuration.
                GetConnectionString("EduZbieraczConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IWebinaryRepository, WebinaryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
