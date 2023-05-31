using MediatR;
using System;
using System.Text;

namespace Antifraud.Service.Operations.Pix
{
    public class RequestPixCommand : IRequest<RequestPixCommandResult>, IAntifraudCommand
    {
        public string TransactionId { get; set; }
        public string Identification { get; set; }
        public decimal Amount { get; set; }

        public RequestPixCommand(string identification, decimal amount)
        {
            TransactionId = Guid.NewGuid().ToString();
            Identification = identification;
            Amount = amount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"[PIX] - Command");
            sb.AppendLine($"        TransactionId={TransactionId}");
            sb.AppendLine($"        Identification={Identification}");
            sb.AppendLine($"        Amount={Amount}");

            return sb.ToString();
        }
    }
}
