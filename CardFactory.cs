using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class CardFactory
    {
        List<ICard> cardProviderList = new List<ICard>();
        public CardFactory(List<ICard> cardList)
        {
            this.cardProviderList = cardList;
        }

        public ICard GetUI(int option)
        {
            return cardProviderList[option];
        }

    }
}
