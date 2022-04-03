using Arkhi.FTGO.KitchenService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arkhi.FTGO.KitchenService.Infra.Data.Configuration
{
    public class KitchenOrderItemEntityTypeConfiguration : IEntityTypeConfiguration<KitchenOrderItem>
    {
        public void Configure(EntityTypeBuilder<KitchenOrderItem> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasDefaultValue(1)
                .IsRequired();
        }
    }
}