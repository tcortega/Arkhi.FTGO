using System.Reflection;
using Arkhi.FTGO.KitchenService.Application.Consumers;
using Arkhi.FTGO.KitchenService.Application.Profiles;
using Arkhi.FTGO.KitchenService.Application.Services;
using Arkhi.FTGO.KitchenService.Infra.Data;
using Arkhi.FTGO.KitchenService.Infra.Repositories;
using Arkhi.FTGO.Libs.Core.Filters;
using Arkhi.FTGO.Libs.Infra.Transactions;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkhi.FTGO.KitchenService.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers(config => { config.Filters.Add<ExceptionFilter>(); });

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Arkhi.FTGO.KitchenService.Infra")));

            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            services.AddAutoMapper(typeof(KitchenOrderProfile).GetTypeInfo().Assembly);

            services.Scan(scan => scan.FromAssemblyOf<KitchenAppService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<KitchenRepository>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<Domain.Services.KitchenService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddMassTransit(bus =>
            {
                bus.AddConsumer<OrderCreatedConsumer>();

                bus.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMq"));

                    cfg.ReceiveEndpoint("send-orders-to-kitchen", e => { e.ConfigureConsumer<OrderCreatedConsumer>(ctx); });
                });
            });
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