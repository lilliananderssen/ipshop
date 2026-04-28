using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using core.Entities.Orders;

namespace infrastructure.Config;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(oi => oi.Price).HasColumnType("decimal(18,2)");
        builder.OwnsOne(c => c.ItemOrdered, i => i.WithOwner());

        
    }
}
