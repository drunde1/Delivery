using Delivery.Core.Models;
using Delivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DataAccess.Reposetories
{
    public class OrdersFiltersRepository : IOrdersFiltersRepository
    {
        private readonly DeliveryDbContext _context;

        public OrdersFiltersRepository(DeliveryDbContext context)
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
               .Where(o => o.District == district && o.DeliveryTime == deliveryTime)
               .OrderBy(o => o.DeliveryTime)
               .AsNoTracking()
               .ToListAsync();

            var orders = orderEntities
                .Select(o => Order.Create(o.Id, o.Weight, o.District, o.DeliveryTime).Order)
                .ToList();

            return orders;
        }

        public async Task CreateFilter(Filter filter)
        {
            var filterEntity = new FilterEntity
            {
                District = filter.District,
                FirstDeliveryTime = filter.FirstDeliveryTime
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

            await _context.Filters
                .Where(f => f.District == district && f.FirstDeliveryTime == firstDelivetytime)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(f => f.Orders, f => orderEntities));
        }
    }
}
