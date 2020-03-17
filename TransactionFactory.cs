using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
