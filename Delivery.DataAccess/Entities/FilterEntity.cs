namespace Delivery.DataAccess.Entities
{
    public class FilterEntity
    {
        public string District { get; set; } = string.Empty;
        public DateTime FirstDeliveryTime { get; set; }
        public List<OrderEntity> Orders { get; set; } = [];
    }
}
