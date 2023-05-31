using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Antifraud.Service.Operations.Ted
{
    public class RequestTedCommandHandler : IRequestHandler<RequestTedCommand, RequestTedCommandResult>
    {
        public Task<RequestTedCommandResult> Handle(RequestTedCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new RequestTedCommandResult()
            {
                TransactionId = request.TransactionId
            });
        }
    }
}
