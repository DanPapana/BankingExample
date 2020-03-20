using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankInfo
    {
        public string IBAN { get; set; }
        public string AccountHolderName { get; set; }
        public decimal CommissionFee { get; set; }
        public decimal CardBalance { get; set; }
    }
}
