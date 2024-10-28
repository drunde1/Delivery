using Delivery.Core.Models;

namespace Delivery.DataAccess.Reposetories
{
    public interface IOrdersFiltersRepository
    {
        Task CreateFilter(Filter filter);
        Task<List<Order>> Get();
        Task<List<Order>> GetFiltered(string district, DateTime deliveryTime);
        Task UpdateFilter(string district, DateTime firstDelivetytime, List<Order> orders);
    }
}