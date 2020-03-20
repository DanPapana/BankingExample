using System;
using System.Collections.Generic;

namespace Bank
{

    class CardUI : ITransactionUI
    {
        private static List<string> cardProviders = new List<string>();

        private ICard cardProvider = null;

        public void ShowMenu()
        {
            PrintMenu();
            bool showMenu = true;
            bool converted;

            while (showMenu)
            {
                converted = Int32.TryParse(Console.ReadLine(), out int input);

                if (converted && input <= 0)
                {
                    showMenu = false;
                }

                if (converted && input <= cardProviders.Count)
                {

                }
            }
        }

        public override string ToString()
        {
            return "Card Payment";
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option: \n0. Exit");

            int index = 1;
            foreach (var element in cardProviders)
            {
                Console.WriteLine($"{ index }. { element }");
                index++;
            }

            Console.Write("\r\nSelect an option: ");
        }
    }
}
