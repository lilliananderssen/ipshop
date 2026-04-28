using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using core.Entities.Orders;

namespace infrastructure.Config;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        
        builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");
        builder.OwnsOne(c => c.ShippingAddress);
        builder.OwnsOne(c => c.PaymentInfo);
        builder.HasMany(c => c.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        builder.Property(c => c.Status).HasConversion(o => o.ToString(), o => Enum
            .Parse<OrderStatus>(o));
        builder.Property(c => c.OrderDate).HasConversion(
            c => c.ToUniversalTime(),
            c => DateTime.SpecifyKind(c, DateTimeKind.Utc)
        );
    }
}
