using Delivery.Core.Models;
using Delivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DataAccess.Reposetories
{
    public class OrdersFiltersReposetory : IOrdersFiltersReposetory
    {
        private readonly DeliveryDbContext _context;

        public OrdersFiltersReposetory(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> Get()
        {
            var orderEntities = await _context.Orders
               .AsNoTracking()
               .ToListAsync();

            var orders = orderEntities
                .Select(o => Order.Create(o.Id, o.Weight, o.District, o.DeliveryTime).Order)
                .ToList();

            return orders;
        }

        public async Task<List<Order>> GetFiltered(string district, DateTime deliveryTime)
        {
            var orderEntities = await _context.Orders
               .Where(o => o.District == district && o.DeliveryTime >= deliveryTime && o.DeliveryTime <= deliveryTime.AddMinutes(30))
               .OrderBy(o => o.DeliveryTime)
               .AsNoTracking()
               .ToListAsync();

            var orders = orderEntities
                .Select(o => Order.Create(o.Id, o.Weight, o.District, o.DeliveryTime).Order)
                .ToList();

            return orders;
        }

        public async Task<bool> GetFilter(string district, DateTime firstDeliveryTime)
        {
            var filterEntity = await _context.Filters
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.District == district &&
                    f.FirstDeliveryTime == firstDeliveryTime);

            if (filterEntity == null)
                return false;

            return true;
            
        }

        public async Task CreateFilter(string district, DateTime firstDeliveryTime)
        {
            var filterEntity = new FilterEntity
            {
                District = district,
                FirstDeliveryTime = firstDeliveryTime,
            };

            await _context.Filters.AddAsync(filterEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFilter(string district, DateTime firstDelivetytime, List<Order> orders)
        {
            var orderEntities = orders
                .Select(o => new OrderEntity
                {
                    Id = o.Id,
                    District = o.District,
                    Weight = o.Weight,
                    DeliveryTime = firstDelivetytime
                })
                .ToList();
            var filterEntity = await _context.Filters
                .Include(f => f.Orders)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.District == district && f.FirstDeliveryTime == firstDelivetytime);

            filterEntity!.Orders = orderEntities;

            await _context.SaveChangesAsync();
        }
    }
}
