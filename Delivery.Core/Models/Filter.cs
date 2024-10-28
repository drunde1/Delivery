namespace Delivery.Core.Models
{
    public class Filter
    {
        public const int MIN_DISTRICT_LENGTH = 5;
        public const int MAX_DISTRICT_LENGTH = 20;

        private Filter(string district, DateTime firstDeliveryTime)
        {
            District = district;
            FirstDeliveryTime = firstDeliveryTime;
        }
    
        public string District { get; } = string.Empty;
        public DateTime FirstDeliveryTime { get; }

        public static (Filter Filter, string Error) Create
            (string district, DateTime firstDeliveryTime)
        {
            var error = string.Empty;

            if (district.Length < MIN_DISTRICT_LENGTH || district.Length > MAX_DISTRICT_LENGTH)
            {
                error = "District length cant be < 5 or > 20";
            }

            var filter = new Filter(district, firstDeliveryTime);

            return (filter, error);
        }
    }
}
