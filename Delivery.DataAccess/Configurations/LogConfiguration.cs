using Delivery.Core.Models;
using Delivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.DataAccess.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Type)
                .IsRequired();

            builder
                .Property(l => l.WhereFrom)
                .HasMaxLength(Log.MAX_WHEREFROM_LENGTH)
                .IsRequired();

            builder
                .Property(l => l.Message)
                .HasMaxLength(Log.MAX_MESSAGE_LENGTH)
                .IsRequired();

            builder
                .Property(l => l.DateTime)
                .IsRequired();
        }
    }
}
