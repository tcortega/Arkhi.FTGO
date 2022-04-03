using Arkhi.FTGO.OrderService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arkhi.FTGO.OrderService.Infra.Data.Configuration
{
    public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasDefaultValue(0M)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasDefaultValue(1)
                .IsRequired();
        }
    }
}