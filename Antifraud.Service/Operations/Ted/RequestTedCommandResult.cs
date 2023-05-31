using System.Text;

namespace Antifraud.Service.Operations.Ted
{
    public class RequestTedCommandResult
    {
        public string TransactionId { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"[TED] - Result");
            sb.AppendLine($"        TransactionId={TransactionId}");

            return sb.ToString();
        }
    }
}
