using MediatR;
using System;
using System.Text;

namespace Antifraud.Service.Operations.Ted
{
    public class RequestTedCommand : IRequest<RequestTedCommandResult>, IAntifraudCommand
    {
        public string TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }

        public RequestTedCommand(string accountNumber, decimal amount)
        {
            TransactionId = Guid.NewGuid().ToString();
            AccountNumber = accountNumber;
            Amount = amount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"[TED] - Command");
            sb.AppendLine($"        TransactionId={TransactionId}");
            sb.AppendLine($"        AccountNumber={AccountNumber}");
            sb.AppendLine($"        Amount={Amount}");

            return sb.ToString();
        }
    }
}
