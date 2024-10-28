namespace Delivery.DataAccess.Reposetories
{
    public class OrdersRepository
    {
        private readonly DeliveryDbContext _context;

        public OrdersRepository(DeliveryDbContext context) 
        {
            _context = context;
        }


    }
}
