namespace Delivery.API.Contracts
{
    public record OrdersResponse(
        Guid Id,
        double Weight,
        string District,
        DateTime DeliveryTime);
}
