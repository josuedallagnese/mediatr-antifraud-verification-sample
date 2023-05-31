using Antifraud.Service.Services;
using System;
using System.Text;

namespace Antifraud.Service
{
    public class AntifraudCommandResult<TResult>
    {
        public bool? FaceId { get; private set; }
        public Guid? OperationId { get; private set; }
        public TResult Result { get; private set; }

        private AntifraudCommandResult() { }

        public static AntifraudCommandResult<TResult> Continue(AntifraudOperation operation, TResult result)
        {
            return new AntifraudCommandResult<TResult>()
            {
                OperationId = operation.Id,
                Result = result
            };
        }

        public static AntifraudCommandResult<TResult> ForceFaceId(AntifraudOperation operation)
        {
            return new AntifraudCommandResult<TResult>()
            {
                FaceId = true,
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

            if (FaceId.HasValue)
                sb.AppendLine($"    FaceId={ForceFaceId}");

            if (Result != null)
                sb.AppendLine($"    {Result.ToString()}");

            return sb.ToString();
        }
    }
}
