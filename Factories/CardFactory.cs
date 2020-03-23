using System.Collections.Generic;

namespace Bank
{
    class CardFactory
    {
        private List<string> cardProviderList = new List<string>();

        public List<string> CreateUIList()
        {
            cardProviderList.Add(new Visa().ToString());
            cardProviderList.Add(new Mastercard().ToString());

            return cardProviderList;
        }

        public ICard getInstance(int option, CardInfo cardInfo)
        {
            switch (option)
            {
                case 1:
                    return new Visa(cardInfo);
                case 2:
                    return new Mastercard(cardInfo);
            }
            return null;
        }
    }
}
