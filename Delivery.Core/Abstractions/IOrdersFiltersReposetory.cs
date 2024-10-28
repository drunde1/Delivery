using Delivery.Core.Models;

namespace Delivery.DataAccess.Reposetories
{
    public interface IOrdersFiltersReposetory
    {
        Task CreateFilter(string district, DateTime firstDelivetytime);
        Task<List<Order>> Get();
        Task<List<Order>> GetFiltered(string district, DateTime deliveryTime);
        Task UpdateFilter(string district, DateTime firstDelivetytime, List<Order> orders);
        Task<bool> GetFilter(string district, DateTime firstDeliveryTime);
    }
}