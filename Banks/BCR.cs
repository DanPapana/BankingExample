using System;

namespace Bank
{
    class BCR : IBank
    {
        public bool checkIBAN(string IBAN)
        {
            return false;
        }

        public int ExecuteTransaction(BankInfo transactionData)
        {
            return 0;
        }
    }
}
