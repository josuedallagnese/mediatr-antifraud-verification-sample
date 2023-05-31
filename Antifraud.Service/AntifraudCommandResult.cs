using Antifraud.Service.Services;
using System;
using System.Text;

namespace Antifraud.Service
{
    public class AntifraudCommandResult<TResult>
    {
        public bool? Check { get; set; }
        public Guid? OperationId { get; set; }
        public TResult Result { get; set; }

        private AntifraudCommandResult() { }

        public static AntifraudCommandResult<TResult> Continue(AntifraudOperation operation, TResult result)
        {
            return new AntifraudCommandResult<TResult>()
            {
                OperationId = operation.Id,
                Result = result
            };
        }

        public static AntifraudCommandResult<TResult> Verify(AntifraudOperation operation)
        {
            return new AntifraudCommandResult<TResult>()
            {
                Check = true,
                OperationId = operation.Id,
            };
        }

        public static AntifraudCommandResult<TResult> Finish(TResult result)
        {
            return new AntifraudCommandResult<TResult>()
            {
                Result = result
            };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"[Antifraud Result]");
            sb.AppendLine($"    OperationId={OperationId}");

            if (Check.HasValue)
                sb.AppendLine($"    Check={Check}");

            if (Result != null)
                sb.AppendLine($"    {Result.ToString()}");

            return sb.ToString();
        }
    }
}
