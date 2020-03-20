using System.Collections.Generic;

namespace Bank
{
    class TransactionFactory
    {
        List<ITransactionUI> transactionTypeList = new List<ITransactionUI>();

        public List<ITransactionUI> CreateUIList()
        {
            transactionTypeList.Add(new CardUI());
            transactionTypeList.Add(new BankUI());

            return transactionTypeList;
        }

        /*
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
         */
    }
}
