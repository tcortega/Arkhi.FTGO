using System;
using System.Reflection;
using Arkhi.FTGO.Libs.Core.Filters;
using Arkhi.FTGO.Libs.Infra.Transactions;
using Arkhi.FTGO.OrderService.Application.Consumers;
using Arkhi.FTGO.OrderService.Application.Profiles;
using Arkhi.FTGO.OrderService.Application.Services;
using Arkhi.FTGO.OrderService.Domain.Services.Interfaces;
using Arkhi.FTGO.OrderService.Infra.Data;
using Arkhi.FTGO.OrderService.Infra.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkhi.FTGO.OrderService.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers(config => { config.Filters.Add<ExceptionFilter>(); });

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Arkhi.FTGO.OrderService.Infra")));

            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            services.AddAutoMapper(typeof(OrderProfile).GetTypeInfo().Assembly);

            services.Scan(scan => scan.FromAssemblyOf<OrderAppService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<OrderRepository>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<Domain.Services.OrderService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddHttpClient<IOrderService, Domain.Services.OrderService>(client =>
            {
                client.BaseAddress = new Uri(configuration["CustomerService"]);
            });

            services.AddMassTransit(bus =>
            {
                bus.AddConsumer<KitchenCancelledConsumer>();

                bus.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMq"));

                    cfg.ReceiveEndpoint("kitchen-cancelled", e => { e.ConfigureConsumer<KitchenCancelledConsumer>(ctx); });
                });
            });
        }

        public static void ConfigureApp(IApplicationBuilder app)
        {
            // Run migrations
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}