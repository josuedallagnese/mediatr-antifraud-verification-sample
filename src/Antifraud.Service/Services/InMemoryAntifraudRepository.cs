using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Antifraud.Service.Services
{
    public class InMemoryAntifraudRepository : IAntifraudRepository
    {
        private readonly IDictionary<Guid, AntifraudOperation> _operations = new Dictionary<Guid, AntifraudOperation>();

        public Task<AntifraudOperation> ContinueAntifraudOperationAsync(Guid operationId)
        {
            var antifraudOperation = _operations[operationId];

            return Task.FromResult(antifraudOperation);
        }

        public Task<AntifraudOperation> StartAntifraudOperationAsync(object antifraudCommand)
        {
            var antifraudOperation = new AntifraudOperation()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                OperationData = JsonSerializer.Serialize(antifraudCommand)
            };

            _operations.Add(antifraudOperation.Id, antifraudOperation);

            return Task.FromResult(antifraudOperation);
        }
    }
}
