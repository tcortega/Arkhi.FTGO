using Arkhi.FTGO.OrderHistoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arkhi.FTGO.OrderHistoryService.Infra.Data.Configuration
{
    public class OrderItemHistoryEntityTypeConfiguration : IEntityTypeConfiguration<OrderItemHistory>
    {
        public void Configure(EntityTypeBuilder<OrderItemHistory> builder)
        {
            builder.Property(x => x.OrderItemId)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();
            //
            // builder.HasOne(x => x.OrderHistory)
            //     .WithMany(x => x.Items);
        }
    }
}