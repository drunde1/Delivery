using Delivery.Core.Models;
using Delivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .HasMany(o => o.Filters)
                .WithMany(f => f.Orders);

            builder
                .Property(o => o.Weight)
                .IsRequired();

            builder
                .Property(o => o.District)
                .HasMaxLength(Order.MAX_DISTRICT_LENGTH)
                .IsRequired();

            builder
                .Property(o => o.DeliveryTime)
                .IsRequired();
        }
    }
}
