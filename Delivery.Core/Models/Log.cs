namespace Delivery.Core.Models
{
    public class Log
    {
        public const int MAX_WHEREFROM_LENGTH = 100;
        public const int MAX_MESSAGE_LENGTH = 100;

        private static string[] Types = ["Info", "Warn", "Fatal", "Debug", "Error"];
        private Log(Guid id, string type, string whereFrom, string message, DateTime dateTime)
        {
            Id = id;
            Type = type;
            WhereFrom = whereFrom;
            Message = message;
        }

        public Guid Id { get; }
        public string Type { get; } = string.Empty;
        public string WhereFrom { get; } = string.Empty;
        public string Message { get; } = string.Empty;
        public DateTime DateTime { get; }
        public static (Log Log, string Error) Create
            (Guid id, string type, string whereFrom, string message)
        {
            var error = string.Empty;

            if (!Types.Contains(type))
            {
                error = "Wrong type of log";
            }

            if (whereFrom == string.Empty || whereFrom.Length > MAX_WHEREFROM_LENGTH) 
            {
                error = "WhereFrom field length cant be zero or > 100";
            }

            if (message == string.Empty || message.Length > MAX_MESSAGE_LENGTH) 
            {
                error = "Message length cant be zero or > 100";
            }

            var log = new Log(id, type, whereFrom, message, DateTime.UtcNow);

            return (log,  error);
        }
    }
}
