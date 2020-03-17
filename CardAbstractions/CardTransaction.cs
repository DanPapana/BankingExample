using System;

namespace Bank
{
    abstract class CardTransaction : ITransactionUI
    {
        public abstract void ExecuteTransaction();
        public abstract void CheckPin();

        public void ShowMenu()
        {
            PrintMenu();
            Console.WriteLine("Options, options");
            bool showMenu = true;

            while (showMenu)
            {
                switch (Console.ReadLine())
                {
                    case "0":
                        showMenu = false;
                        MainMenuUI.ShowMenu();
                        break;

                    case "1":
                        ExecuteTransaction();
                        break;

                    case "2":
                        CheckPin();
                        break;

                    default:
                        break;
                }
            }
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option: \n0. Exit");

            Console.WriteLine("1. Execute Transaction");
            Console.WriteLine("2. Check Pin");

            Console.Write("\r\nSelect an option: ");
        }
    }
}
