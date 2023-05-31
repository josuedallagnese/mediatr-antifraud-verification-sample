using System;

namespace Antifraud.Service.Services
{
    public class AntifraudOperation
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool Verified { get; set; }
        public string OperationData { get; set; }
    }
}
