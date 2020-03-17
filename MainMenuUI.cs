using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class MainMenuUI
    {
        private static List<ITransactionUI> transactionTypes = new List<ITransactionUI>()
        {
            {null },
            {new CardUI() },
            {new BankUI() }
        };

        public static void ShowMenu()
        {
            PrintMenu();
            Console.WriteLine("Main!");
            ITransactionUI IUI = null;
            TransactionFactory transactionTypeFactory = new TransactionFactory(transactionTypes);
            bool showMenu = true;

            while (showMenu)
            {
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                {
                    showMenu = false;
                    MainMenuUI.ShowMenu();
                }

                IUI = transactionTypeFactory?.GetUI(input);
                
                if (IUI != null)
                    IUI.ShowMenu();
            }
        }

        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option: \n0 Exit");

            Console.WriteLine("1. Card Payment");
            Console.WriteLine("2. Bank Payment");

            Console.Write("\r\nSelect an option: ");
        }
    }
}
