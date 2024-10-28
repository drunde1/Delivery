using Delivery.DataAccess.Configurations;
using Delivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DataAccess
{
    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options)
            : base (options)
        {

        }

        public DbSet<FilterEntity> Filters { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<LogEntity> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new FilterConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
