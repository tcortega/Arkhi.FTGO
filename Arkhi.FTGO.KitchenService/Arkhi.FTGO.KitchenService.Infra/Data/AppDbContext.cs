using Arkhi.FTGO.KitchenService.Domain.Entities;
using Arkhi.FTGO.KitchenService.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Arkhi.FTGO.KitchenService.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<KitchenOrderItem> KitchenOrderItems { get; set; }
        public DbSet<KitchenOrder> KitchenOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KitchenOrderEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}