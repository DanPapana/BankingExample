using System.Collections.Generic;

namespace Bank
{
    class TransactionFactory
    {
        List<ITransactionUI> transactionTypeList = new List<ITransactionUI>();
        public TransactionFactory(List<ITransactionUI> typeList)
        {
            this.transactionTypeList = typeList;
        }

        public ITransactionUI GetUI(int option)
        {
            return transactionTypeList[option];
        }
    }
}
