using System.Text;

namespace Antifraud.Service.Operations.Pix
{
    public class RequestPixCommandResult
    {
        public string TransactionId { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"[PIX] - Result");
            sb.AppendLine($"        TransactionId={TransactionId}");

            return sb.ToString();
        }
    }
}
