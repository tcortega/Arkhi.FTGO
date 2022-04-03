using System.Reflection;
using Arkhi.FTGO.CustomerService.Application.Profiles;
using Arkhi.FTGO.CustomerService.Application.Services;
using Arkhi.FTGO.CustomerService.Infra.Data;
using Arkhi.FTGO.CustomerService.Infra.Repositories;
using Arkhi.FTGO.Libs.Core.Filters;
using Arkhi.FTGO.Libs.Infra.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkhi.FTGO.CustomerService.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers(config => { config.Filters.Add<ExceptionFilter>(); });

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Arkhi.FTGO.CustomerService.Infra")));

            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            services.AddAutoMapper(typeof(CustomerProfile).GetTypeInfo().Assembly);

            services.Scan(scan => scan.FromAssemblyOf<CustomerAppService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<CustomerRepository>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<Domain.Services.CustomerService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        public static void ConfigureApp(IApplicationBuilder app)
        {
            // Run migrations
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (serviceScope is null) return;

            var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}