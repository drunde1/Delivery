using Delivery.Core.Models;

namespace Delivery.Application.Services
{
    public interface IOrdersService
    {
        Task<List<Order>> GetFiltered(string district, DateTime firstDeliveryTime);
        Task<List<Order>> GetOrders();
    }
}