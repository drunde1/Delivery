using Delivery.Core.Models;
using Delivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.DataAccess.Configurations
{
    public class FilterConfiguration : IEntityTypeConfiguration<FilterEntity>
    {
        public void Configure(EntityTypeBuilder<FilterEntity> builder)
        {
            builder
                .HasKey(f => new { f.District, f.FirstDeliveryTime });

            builder
                .HasMany(f => f.Orders)
                .WithMany(o => o.Filters);

            builder
                .Property(f => f.District)
                .HasMaxLength(Filter.MAX_DISTRICT_LENGTH)
                .IsRequired();

            builder
                .Property(f => f.FirstDeliveryTime)
                .IsRequired();
        }
    }
}
