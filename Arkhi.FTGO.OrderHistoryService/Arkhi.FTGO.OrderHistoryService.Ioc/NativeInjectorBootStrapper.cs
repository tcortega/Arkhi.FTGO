using System.Reflection;
using Arkhi.FTGO.Libs.Core.Filters;
using Arkhi.FTGO.Libs.Infra.Transactions;
using Arkhi.FTGO.OrderHistoryService.Application.Consumers;
using Arkhi.FTGO.OrderHistoryService.Application.Profiles;
using Arkhi.FTGO.OrderHistoryService.Application.Services;
using Arkhi.FTGO.OrderHistoryService.Infra.Data;
using Arkhi.FTGO.OrderHistoryService.Infra.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkhi.FTGO.OrderHistoryService.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers(config => { config.Filters.Add<ExceptionFilter>(); });

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Arkhi.FTGO.OrderHistoryService.Infra")));

            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            services.AddAutoMapper(typeof(OrderHistoryProfile).GetTypeInfo().Assembly);

            services.Scan(scan => scan.FromAssemblyOf<OrderHistoryAppService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<OrderHistoryRepository>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblyOf<Domain.Services.OrderHistoryService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddMassTransit(bus =>
            {
                bus.AddConsumer<OrderCreatedConsumer>();
                bus.AddConsumer<KitchenCancelledConsumer>();
                bus.AddConsumer<DeliveryStartedConsumer>();
                bus.AddConsumer<DeliveryFinishedConsumer>();
                bus.AddConsumer<KitchenFinishedConsumer>();

                bus.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMq"));

                    cfg.ReceiveEndpoint("send-order-to-history", e => { e.ConfigureConsumer<OrderCreatedConsumer>(ctx); });

                    cfg.ReceiveEndpoint("send-cancel-order-to-history", e => { e.ConfigureConsumer<KitchenCancelledConsumer>(ctx); });

                    cfg.ReceiveEndpoint("send-delivery-started-to-history", e => { e.ConfigureConsumer<DeliveryStartedConsumer>(ctx); });

                    cfg.ReceiveEndpoint("send-delivery-finished-to-history", e => { e.ConfigureConsumer<DeliveryFinishedConsumer>(ctx); });

                    cfg.ReceiveEndpoint("send-kitchen-finished-to-history", e => { e.ConfigureConsumer<KitchenFinishedConsumer>(ctx); });
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