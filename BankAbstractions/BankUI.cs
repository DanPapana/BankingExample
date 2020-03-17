using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    class BankUI : ITransactionUI
    {
        private static Dictionary<string, IBank> banks = new Dictionary<string, IBank>()
        {
            {"Exit", null},
            {"BCR", new BCR() },
            {"ING", new ING() }
        };

        public static IBank getBank(string bankName)
        {
            if (banks.ContainsKey(bankName))
                return banks[bankName];
            return null;
        }

        public void ShowMenu()
        {
            PrintMenu();
            Console.WriteLine("Bank!");
            IBank IBank = null;
            List<IBank> bankProviders = banks.Values.ToList<IBank>();
            BankFactory bankFactory = new BankFactory(bankProviders);
            bool showMenu = true;

            while (showMenu)
            {
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                {
                    showMenu = false;
                    MainMenuUI.ShowMenu();
                }

                IBank = bankFactory?.GetUI(input);

                if (IBank != null)
                    IBank.ShowMenu();
            }
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option: \n0. Exit");

            Console.WriteLine("1. BCR");
            Console.WriteLine("2. ING");

            Console.Write("\r\nSelect an option: ");
        }
    }
}
