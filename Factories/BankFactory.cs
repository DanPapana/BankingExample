using System.Collections.Generic;

namespace Bank
{
    class BankFactory
    {
        List<string> cardProviderList = new List<string>();
        public List<string> CreateUIList()
        {
            cardProviderList.Add(new ING().ToString());
            cardProviderList.Add(new BCR().ToString());

            return cardProviderList;
        }

        public IBank getInstance(int option, BankInfo bankInfo)
        {
            switch (option)
            {
                case 1:
                    return new ING(bankInfo);
                case 2:
                    return new BCR(bankInfo);
            }
            return null;
        }
    }
}
