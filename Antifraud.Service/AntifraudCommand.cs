using MediatR;
using System;
using System.Text;

namespace Antifraud.Service
{
    public class AntifraudCommand<TCommand, TResult> : IRequest<AntifraudCommandResult<TResult>>
        where TCommand : IRequest<TResult>
    {
        public Guid? OperationId { get; set; }
        public TCommand Command { get; set; }

        private AntifraudCommand() { }

        public static AntifraudCommand<TCommand, TResult> Continue(Guid operationId)
        {
            return new AntifraudCommand<TCommand, TResult>()
            {
                OperationId = operationId,
            };
        }

        public static AntifraudCommand<TCommand, TResult> Finish(TCommand command)
        {
            return new AntifraudCommand<TCommand, TResult>()
            {
                Command = command
            };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"[Antifraud Command]");

            if (OperationId.HasValue)
                sb.AppendLine($"    OperationId={OperationId}");
            else
                sb.AppendLine($"    OperationId=");

            if (Command != null)
                sb.AppendLine($"    {Command.ToString()}");

            return sb.ToString();
        }
    }
}
