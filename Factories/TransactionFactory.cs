using System.Collections.Generic;

namespace Bank
{
    class TransactionFactory
    {
        List<string> transactionTypeList = new List<string>();

        public List<string> CreateUIList()
        {
            transactionTypeList.Add(new CardUI().ToString());
            transactionTypeList.Add(new BankUI().ToString());

            return transactionTypeList;
        }

        public ITransactionUI getInstance(int option)
        {
            switch (option)
            {
                case 1:
                    return new CardUI();
                case 2:
                    return new BankUI();
            }
            return null;
        }
    }
}
