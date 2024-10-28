using Delivery.Core.Models;
using Delivery.DataAccess.Reposetories;

namespace Delivery.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersFiltersReposetory _orderReposetory;
        private readonly ILogReposetory _logReposetory;

        public OrdersService(IOrdersFiltersReposetory orderReposetory, ILogReposetory logReposetory)
        {
            _orderReposetory = orderReposetory;
            _logReposetory = logReposetory;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderReposetory.Get();
        }

        public async Task<List<Order>> GetFiltered(string district, DateTime firstDeliveryTime)
        {
            if (firstDeliveryTime.Kind != DateTimeKind.Utc) 
            {
                TimeSpan delta = TimeZoneInfo.Local.GetUtcOffset(firstDeliveryTime);
                double utcOffset = delta.TotalHours;
                firstDeliveryTime = new DateTime(
                    firstDeliveryTime.Year,
                    firstDeliveryTime.Month,
                    firstDeliveryTime.Day,
                    firstDeliveryTime.Hour,
                    firstDeliveryTime.Minute,
                    firstDeliveryTime.Second,
                    DateTimeKind.Utc).AddHours(-utcOffset);

                await _logReposetory.Create(Log.Create(
                    Guid.NewGuid(),
                    "Warning",
                    "Delivery.Application.Services.OrdersService.GetFiltered",
                    "Дата переведена в utc, возможна потеря данных").Log);
            }

            var orders = await _orderReposetory.GetFiltered(district, firstDeliveryTime);

            if (!await _orderReposetory.GetFilter(district, firstDeliveryTime))
            {
                await _orderReposetory.CreateFilter(district, firstDeliveryTime);
                await _orderReposetory.UpdateFilter(district, firstDeliveryTime, orders);

                await _logReposetory.Create(Log.Create(
                    Guid.NewGuid(),
                    "Warning",
                    "Delivery.Application.Services.OrdersService.GetFiltered",
                    $"Филтрация {district} - {firstDeliveryTime.ToString("yyyy-mm-dd hh:mm:ss")} сохранена").Log);
            }

            return orders;
        }
    }
}
