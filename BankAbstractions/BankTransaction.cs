using System;

namespace Bank
{
    abstract class BankTransaction
    {

        public abstract void ExecuteTransaction();
        public abstract void ExecuteTransaction(IBank bankName);

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
                        break;

                    case "1":
                        ExecuteTransaction();
                        break;

                    case "2":
                        OtherBankTrans();
                        break;

                    default:
                        break;
                }
            }
        }

        private void OtherBankTrans()
        {
            Console.WriteLine("Write the name of the bank");
            string name = Console.ReadLine();
            IBank destination = BankUI.getBank(name);
            if (destination != null)
            {
                ExecuteTransaction(destination);
            }
            else
            {
                Console.WriteLine("Wrong bank name. Select your option:");
            }
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option: \n0 Exit");

            Console.WriteLine("1. Execute Normal Transaction");
            Console.WriteLine("2. Execute Transaction to another bank");

            Console.Write("\r\nSelect an option: ");
        }

    }
}
