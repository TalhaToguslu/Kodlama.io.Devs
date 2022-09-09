using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            // Db connection kısmı
            services.AddDbContext<BaseDBContext>(options =>
                                                     options.UseSqlServer(
                                                         // appsettings.json'dan git burayı oku getir diyoruz.
                                                         configuration.GetConnectionString("KodlamaIODevsConnectionString")));
            // Dependicy Injection
            services.AddScoped<IProgramingLanguageRepository, ProgramingLanguageRepository>();

            return services;
        }
    }
}
