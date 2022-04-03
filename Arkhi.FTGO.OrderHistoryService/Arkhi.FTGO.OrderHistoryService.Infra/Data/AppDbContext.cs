using Arkhi.FTGO.OrderHistoryService.Domain.Entities;
using Arkhi.FTGO.OrderHistoryService.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Arkhi.FTGO.OrderHistoryService.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<OrderItemHistory> OrderItemsHistory { get; set; }
        public DbSet<OrderHistory> OrdersHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderHistoryEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}