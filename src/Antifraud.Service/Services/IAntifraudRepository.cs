using System;
using System.Threading.Tasks;

namespace Antifraud.Service.Services
{
    public interface IAntifraudRepository
    {
        Task<AntifraudOperation> StartAntifraudOperationAsync(object antifraudCommand);
        Task<AntifraudOperation> ContinueAntifraudOperationAsync(Guid operationId);
    }
}
