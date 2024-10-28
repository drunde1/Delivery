namespace Delivery.DataAccess.Entities
{
    public class LogEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string WhereFrom { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
