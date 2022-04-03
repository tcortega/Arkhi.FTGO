using System;
using System.Reflection;
using Arkhi.FTGO.DeliveryService.Application.Consumers;
using Arkhi.FTGO.DeliveryService.Application.Profiles;
using Arkhi.FTGO.DeliveryService.Application.Services;
using Arkhi.FTGO.DeliveryService.Domain.Services.Interfaces;
using Arkhi.FTGO.DeliveryService.Infra.Data;
using Arkhi.FTGO.DeliveryService.Infra.Repositories;
using Arkhi.FTGO.Libs.Core.Filters;
using Arkhi.FTGO.Libs.Infra.Transactions;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkhi.FTGO.DeliveryService.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers(config => { config.Filters.Add<ExceptionFilter>(); });

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Arkhi.FTGO.DeliveryService.Infra")));

            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            services.AddAutoMapper(typeof(DeliveryOrderProfile).GetTypeInfo().Assembly);

            services.Scan(scan => scan.FromAssemblyOf<DeliveryAppService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<KitchenRepository>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<Domain.Services.DeliveryService>()
                .AddClasses(classes => classes.InNamespaces("*.Services"))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddHttpClient<IDeliveryService, Domain.Services.DeliveryService>(client =>
            {
                client.BaseAddress = new Uri(configuration["CustomerService"]);
            });

            services.AddMassTransit(bus =>
            {
                bus.AddConsumer<KitchenFinishedConsumer>();
                bus.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMq"));
                    cfg.ReceiveEndpoint("send-orders-to-delivery", e => { e.ConfigureConsumer<KitchenFinishedConsumer>(ctx); });
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