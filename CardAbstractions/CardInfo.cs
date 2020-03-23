using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    
    class CardInfo
    {
        public enum TransactionStatus { Succeeded = 0, UnknownFailure = 1, NotEnoughFunds = 2, WrongPin = 3, CardExpired = 4 }

        public TransactionStatus Status { get; set; }
        public string IBAN { get; set; }
        public string CardNumber { get; set; }
        public string CardOwner { get; set; }
        public decimal CardBalance { get; set; }
        public int PIN { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
