using Arkhi.FTGO.CustomerService.Domain.Entities;
using Arkhi.FTGO.CustomerService.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Arkhi.FTGO.CustomerService.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}