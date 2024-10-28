using Delivery.Core.Models;

namespace Delivery.DataAccess.Reposetories
{
    public interface ILogReposetory
    {
        Task Create(Log log);
    }
}