using Antifraud.Service.Operations;
using Antifraud.Service.Services;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Antifraud.Service
{
    public class AntifraudCommandHandler<TCommand, TResult> : IRequestHandler<AntifraudCommand<TCommand, TResult>, AntifraudCommandResult<TResult>>
        where TCommand : IRequest<TResult>
    {
        private readonly IMediator _mediator;
        private readonly IAntifraudClient _antifraudService;
        private readonly IAntifraudRepository _antifraudRepository;

        public AntifraudCommandHandler(IMediator mediator, IAntifraudClient antifraudService, IAntifraudRepository antifraudRepository)
        {
            _mediator = mediator;
            _antifraudService = antifraudService;
            _antifraudRepository = antifraudRepository;
        }

        public async Task<AntifraudCommandResult<TResult>> Handle(AntifraudCommand<TCommand, TResult> request, CancellationToken cancellationToken)
        {
            if (request.OperationId.HasValue)
            {
                var operation = await _antifraudRepository.ContinueAntifraudOperationAsync(request.OperationId.Value);

                var commandToExecute = JsonSerializer.Deserialize<TCommand>(operation.OperationData);

                var result = await _mediator.Send(commandToExecute, cancellationToken);

                return AntifraudCommandResult<TResult>.Continue(operation, result);
            }

            var checkAntifraud = await _antifraudService.Check(request.Command as IAntifraudCommand);

            if (checkAntifraud)
            {
                var operation = await _antifraudRepository.StartAntifraudOperationAsync(request.Command);

                return AntifraudCommandResult<TResult>.ForceFaceId(operation);
            }

            var response = await _mediator.Send(request.Command, cancellationToken);

            return AntifraudCommandResult<TResult>.Finish(response);

            throw new NotSupportedException("This operation is only for antifraud.");
        }
    }
}
