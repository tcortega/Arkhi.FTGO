using Arkhi.FTGO.KitchenService.Domain.Entities;
using Arkhi.FTGO.KitchenService.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arkhi.FTGO.KitchenService.Infra.Data.Configuration
{
    public class KitchenOrderEntityTypeConfiguration : IEntityTypeConfiguration<KitchenOrder>
    {
        public void Configure(EntityTypeBuilder<KitchenOrder> builder)
        {
            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Navigation(x => x.Items)
                .AutoInclude();

            builder.Property(x => x.Status)
                .HasDefaultValue(KitchenOrderStatus.Preparing)
                .IsRequired();
        }
    }
}