namespace Delivery.DataAccess.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public double Weight { get; set; }
        public string District { get; set; } = string.Empty;
        public DateTime DeliveryTime { get; set; }
        public List<FilterEntity> Filters { get; set; } = [];
    }
}
