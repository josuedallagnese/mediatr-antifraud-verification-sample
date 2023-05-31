using Antifraud.Service.Operations;
using System.Threading.Tasks;

namespace Antifraud.Service.Services
{
    public interface IAntifraudClient
    {
        Task<bool> Check(IAntifraudCommand antifraudCommand);
    }
}
