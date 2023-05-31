using Antifraud.Service.Operations;
using System.Threading.Tasks;

namespace Antifraud.Service.Services
{
    public class InMemoryAntifraudClient : IAntifraudClient
    {
        public Task<bool> Check(IAntifraudCommand antifraudCommand)
        {
            if (antifraudCommand.Amount > 10)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
