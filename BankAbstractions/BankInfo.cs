using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankInfo
    {
        public enum TransactionStatus { Succeeded = 0, UnknownFailure = 1, NotEnoughFunds = 2 };
        public TransactionStatus Status { get; set; }
        public string IBAN { get; set; }
        public string AccountHolderName { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
