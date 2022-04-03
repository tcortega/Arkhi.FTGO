using Arkhi.FTGO.OrderService.Domain.Entities;
using Arkhi.FTGO.OrderService.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Arkhi.FTGO.OrderService.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}