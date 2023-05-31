using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Antifraud.Service.Operations.Pix
{
    public class RequestPixCommandHandler : IRequestHandler<RequestPixCommand, RequestPixCommandResult>
    {
        public Task<RequestPixCommandResult> Handle(RequestPixCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new RequestPixCommandResult()
            {
                TransactionId = request.TransactionId
            });
        }
    }
}
