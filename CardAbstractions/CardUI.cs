using System;
using System.Collections.Generic;

namespace Bank
{

    class CardUI : ITransactionUI
    {
        private static List<ICard> cardProviders = new List<ICard>()
        {
            {null },
            {new Visa() },
            {new Mastercard() }
        };

        public void ShowMenu()
        {
            PrintMenu();
            Console.WriteLine("Card!");
            ICard ICard = null;
            CardFactory cardFactory = new CardFactory(cardProviders);
            bool showMenu = true;

            while (showMenu)
            {
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                {
                    showMenu = false;
                    MainMenuUI.ShowMenu();
                }

                ICard = cardFactory?.GetUI(input);

                if (ICard != null)
                    ICard.ShowMenu();
            }
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option: \n0. Exit");

            Console.WriteLine("1. Visa");
            Console.WriteLine("2. Mastercard");

            Console.Write("\r\nSelect an option: ");
        }
    }
}
