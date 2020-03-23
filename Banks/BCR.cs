using System;

namespace Bank
{
    class BCR : IBank
    {
        private BankInfo bankInfo = null;

        public BankInfo ExecuteTransaction(BankInfo transactionData, decimal sendAmount)
        {
            if (GetBalance() < sendAmount)
            {
                transactionData.Status = BankInfo.TransactionStatus.NotEnoughFunds;
                return transactionData;
            }

            transactionData.Status = BankInfo.TransactionStatus.Succeeded;
            return transactionData;
        }

        public BCR() { }
        public BCR(BankInfo bankInfo)
        {
            this.bankInfo = bankInfo;
        }

        public decimal GetBalance()
        {
            if (bankInfo != null)
            {
                return bankInfo.AccountBalance;
            }
            return 0;
        }

        public BankInfo MatchIBAN(string IBAN)
        {
            if (IBAN == bankInfo.IBAN)
            {
                return bankInfo;
            }
            return null;
        }

        public override string ToString()
        {
            return "BCR Payment";
        }
    }
}
