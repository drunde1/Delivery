namespace Delivery.Core.Models
{
    public class Order
    {
        public static int MIN_DISTRICT_LENGTH = 5;
        public static int MAX_DISTRICT_LENGTH = 20;

        private Order(Guid id, double weight, string district, DateTime deliveryTime)
        {
            Id = id;
            Weight = weight;
            District = district;
            DeliveryTime = deliveryTime;
        }
        
        public Guid Id { get; }
        public double Weight { get; }
        public string District { get; } = string.Empty;
        public DateTime DeliveryTime { get; }

        public static (Order Order, string Error) Create
            (Guid id, double weight, string district, DateTime deliveryTime)
        {
            var error = string.Empty;

            if (district.Length < MIN_DISTRICT_LENGTH)
                error = "District name cant be less than 5";
            else if (district.Length > MAX_DISTRICT_LENGTH)
                error = "District name cant be bigger than 20";

            if (weight == 0)
                error = "Weight cant be 0";

            var order = new Order(id, weight, district, deliveryTime);

            return (order, error);
        }
        
    }
}
