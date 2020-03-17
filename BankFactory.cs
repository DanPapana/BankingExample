using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
