using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    class BankUI : ITransactionUI
    {
        private static List<string> bankStrings = new BankFactory().CreateUIList();
        private List<IBank> bankList = new List<IBank>();
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
                else if (converted && input <= bankStrings.Count)
                {
                    IBank bankInstance = CreateBank(input);
                    if (bankInstance != null)
                    {
                        ShowInstanceMenu(bankInstance);
                    } else {
                        Console.WriteLine("Bank Account failed to be created");
                    }
                }
            }
        }

        private IBank CreateBank(int option)
        {
            BankInfo bankInfo = new BankInfo();

            Console.WriteLine("IBAN");
            bankInfo.IBAN = Console.ReadLine();

            Console.WriteLine("Account Owner Name");
            bankInfo.AccountHolderName = Console.ReadLine();

            Console.WriteLine("Account Balance");
            bankInfo.AccountBalance = Decimal.Parse(Console.ReadLine());

            return new BankFactory()?.getInstance(option, bankInfo);
        }

        private void ShowInstanceMenu(IBank sendingBank)
        {
            bool showMenu = true;
            while(showMenu)
            {
                PrintBankOperations(sendingBank);
                bool converted = Int32.TryParse(Console.ReadLine(), out int input);

                if (converted)
                {
                    switch(input)
                    {
                        case 0:
                            showMenu = false;
                            break;
                        case 1:
                            TransactionResult(SendingMoney(sendingBank).Status);
                            break;
                        case 2:
                            Console.WriteLine(sendingBank.GetBalance());
                            break;
                    }
                }
            }
        }

        private void TransactionResult(BankInfo.TransactionStatus transactionStatus)
        {
            switch (transactionStatus)
            {
                case BankInfo.TransactionStatus.Succeeded:
                    Console.WriteLine("Payment successful!");
                    break;
                case BankInfo.TransactionStatus.NotEnoughFunds:
                    Console.WriteLine("Not Enough Funds!");
                    break;
                case BankInfo.TransactionStatus.UnknownFailure:
                    Console.WriteLine("Uknown failure!");
                    break;
            }
        }

        private BankInfo SendingMoney(IBank sendingBank)
        {
            Console.Clear();
            BankInfo targetInfo = new BankInfo();
            Console.WriteLine("Sending money to:");
            Console.WriteLine("IBAN");
            targetInfo.IBAN = Console.ReadLine();
            Console.WriteLine("Sending amount");
            decimal amount = Decimal.Parse(Console.ReadLine());

            foreach (IBank bank in bankList)
            {
                if (bank.MatchIBAN(targetInfo.IBAN) != null)
                {
                    targetInfo = bank.MatchIBAN(targetInfo.IBAN);
                }
            }

            return sendingBank.ExecuteTransaction(targetInfo, amount);
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option: \n0. Exit");
            int index = 1;
            foreach (var element in bankStrings)
            {
                Console.WriteLine($"{ index }. { element }");
                index++;
            }
            Console.Write("\r\nSelect an option: ");
        }

        private void PrintBankOperations(IBank targetBank)
        {
            Console.WriteLine(targetBank.ToString());
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Send Money");
            Console.WriteLine("2. Balance");
        }

        public override string ToString()
        {
            return "Bank Payment";
        }
    }
}
