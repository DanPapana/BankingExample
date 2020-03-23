using System;
using System.Collections.Generic;

namespace Bank
{
    class MainMenuUI
    {
        private static List<string> transactionTypes = new TransactionFactory().CreateUIList();
        
        public void ShowMenu()
        {
            bool showMenu = true;
        
            while (showMenu)
            {
                PrintMenu();
                bool converted = Int32.TryParse(Console.ReadLine(), out int input);

                if (converted && input <= 0)
                {
                    showMenu = false;
                } 
                else if (converted && input > 0 && input <= transactionTypes.Count)
                {
                    ITransactionUI transaction = new TransactionFactory()?.getInstance(input);
                    if (transaction != null)
                    {
                        transaction.ShowMenu();
                    }
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
