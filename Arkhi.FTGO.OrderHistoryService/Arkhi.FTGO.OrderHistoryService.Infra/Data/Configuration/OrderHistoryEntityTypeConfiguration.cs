using Arkhi.FTGO.OrderHistoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arkhi.FTGO.OrderHistoryService.Infra.Data.Configuration
{
    public class OrderHistoryEntityTypeConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Navigation(x => x.Items)
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .AutoInclude();
        }
    }
}