using Arkhi.FTGO.DeliveryService.Domain.Entities;
using Arkhi.FTGO.DeliveryService.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Arkhi.FTGO.DeliveryService.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryOrderEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}