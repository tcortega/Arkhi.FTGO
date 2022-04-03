using Arkhi.FTGO.DeliveryService.Domain.Entities;
using Arkhi.FTGO.DeliveryService.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arkhi.FTGO.DeliveryService.Infra.Data.Configuration
{
    public class DeliveryOrderEntityTypeConfiguration : IEntityTypeConfiguration<DeliveryOrder>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrder> builder)
        {
            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.CustomerName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.DeliveryAddress)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasDefaultValue(DeliveryOrderStatus.Pending)
                .IsRequired();
        }
    }
}