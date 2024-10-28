using Delivery.Core.Models;
using Delivery.DataAccess.Entities;

namespace Delivery.DataAccess.Reposetories
{
    public class LogReposetory : ILogReposetory
    {
        private readonly DeliveryDbContext _context;

        public LogReposetory(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task Create(Log log)
        {
            var logEntity = new LogEntity
            {
                Id = log.Id,
                Type = log.Type,
                WhereFrom = log.WhereFrom,
                Message = log.Message,
            };

            await _context.AddAsync(logEntity);
            await _context.SaveChangesAsync();
        }
    }
}
