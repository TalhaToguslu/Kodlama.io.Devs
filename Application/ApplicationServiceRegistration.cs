using Application.Features.ProgramingLanguages.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Auto mapper, mapleme profillerini ekliycek.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // MediatR dahil ediyoruz.
            services.AddMediatR(Assembly.GetExecutingAssembly());
            // Programin langauge business kurallarını ekledik. IOC'ye
            services.AddScoped<ProgramingLanguageBusinessRules>();

            // Validation entegrasyonu
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            // Validation pipeline ekleme.
            // MediatR isteği yakaladığında önce RequestValidationBehavior işlemleri yap diyoruz.
            // MediatR'ın çalıştığı kısımlara bir AOP ekliyoruza aslında. Bir attribute ASPECT. Validation ASPECT. 
            // RequestValidationBehavior
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;

        }
    }
}
