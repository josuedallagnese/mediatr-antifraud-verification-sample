using System;

namespace Antifraud.Service.Services
{
    public class AntifraudOperation
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool ExecuteBiometrics { get; set; }
        public string OperationData { get; set; }
    }
}
