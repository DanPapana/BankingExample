using System;
using System.Collections.Generic;

namespace Bank
{
    class MainMenuUI
    {
        private static List<ITransactionUI> transactionTypes = new TransactionFactory().CreateUIList();
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

                if (converted && input <= transactionTypes.Count)
                {
                    transactionTypes[input - 1].ShowMenu();
                    //ITransactionUI transaction = new TransactionFactory()?.getInstance(input);
                }
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option: \n0. Exit");

            int index = 1;
            foreach (var element in transactionTypes)
            {
                Console.WriteLine($"{ index }. { element }");
                index++;
            }

            Console.Write("\r\nSelect an option: ");
        }
    }
}
