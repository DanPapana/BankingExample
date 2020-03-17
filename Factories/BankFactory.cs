using System.Collections.Generic;

namespace Bank
{
    class BankFactory
    {
        List<IBank> bankList = new List<IBank>();
        public BankFactory(List<IBank> bankList)
        {
            this.bankList = bankList;
        }

        public IBank GetUI(int option)
        {
            return bankList[option];
        }
    }
}
