using System;
using System.Collections.Generic;

namespace Bank
{
    class CardUI : ITransactionUI
    {
        private static List<string> cardProviders = new CardFactory().CreateUIList();
        private List<ICard> cardList = new List<ICard>();
        
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
                else if (converted && input <= cardProviders.Count)
                {
                    ICard cardInstance = CreateCard(input);
                    if (cardInstance != null)
                    {
                        cardList.Add(cardInstance);
                        ShowInstanceMenu(cardInstance);
                    } else
                    {
                        Console.WriteLine("Card failed to be created");
                    }
                }
            }
        }

        private void ShowInstanceMenu(ICard sendingCard)
        {
            bool showMenu = true;
            while (showMenu)
            {
                PrintCardOperations(sendingCard);
                bool converted = Int32.TryParse(Console.ReadLine(), out int input);

                if (converted)
                {
                    switch (input)
                    {
                        case 0:
                            showMenu = false;
                            break;
                        case 1:
                            Console.WriteLine("Type in your PIN code");
                            converted = Int32.TryParse(Console.ReadLine(), out int pin);
                            
                            if (!sendingCard.CheckPin(pin))
                            {
                                TransactionResult(CardInfo.TransactionStatus.WrongPin);
                                break;
                            }
                            
                            if (SendingMoney(sendingCard) == null)
                            {
                                TransactionResult(CardInfo.TransactionStatus.UnknownFailure);
                                break;
                            }

                            TransactionResult(SendingMoney(sendingCard).Status);
                           
                            break;
                        case 2:
                            Console.WriteLine(sendingCard.GetBalance());
                            break;
                    }
                }
            }
        }

        private void TransactionResult(CardInfo.TransactionStatus transactionStatus)
        {
            switch (transactionStatus)
            {
                case CardInfo.TransactionStatus.Succeeded:
                    Console.WriteLine("Payment successful!");
                    break;
                case CardInfo.TransactionStatus.WrongPin:
                    Console.WriteLine("Wrong pin!");
                    break;
                case CardInfo.TransactionStatus.NotEnoughFunds:
                    Console.WriteLine("Not Enough Funds!");
                    break;
                case CardInfo.TransactionStatus.CardExpired:
                    Console.WriteLine("Card Expired!");
                    break;
                case CardInfo.TransactionStatus.UnknownFailure:
                    Console.WriteLine("Uknown failure!");
                    break;
            }
        }

        private CardInfo SendingMoney(ICard sendingBank)
        {
            Console.Clear();
            CardInfo targetInfo = new CardInfo();
            Console.WriteLine("Sending money to:");
            Console.WriteLine("IBAN");
            targetInfo.IBAN = Console.ReadLine();
            Console.WriteLine("Sending amount");
            decimal amount = Decimal.Parse(Console.ReadLine());

            foreach (ICard card in cardList)
            {
                if (card.MatchIBAN(targetInfo.IBAN) != null)
                {
                    targetInfo = card.MatchIBAN(targetInfo.IBAN);
                    return sendingBank.ExecuteTransaction(targetInfo, amount);
                }
            }
            return null;
        }

        private void PrintCardOperations(ICard targetCard)
        {
            Console.WriteLine(targetCard.ToString());
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Send Money");
            Console.WriteLine("2. Balance");
        }

        private ICard CreateCard(int option)
        {
            CardInfo cardInfo = new CardInfo();

            Console.WriteLine("IBAN");
            cardInfo.IBAN = Console.ReadLine();

            Console.WriteLine("Card Number");
            cardInfo.CardNumber = Console.ReadLine();

            Console.WriteLine("Card Owner");
            cardInfo.CardOwner = Console.ReadLine();

            Console.WriteLine("PIN");
            cardInfo.PIN = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Balance");
            cardInfo.CardBalance = Int32.Parse(Console.ReadLine());

            cardInfo.ExpiryDate = DateTime.Now.AddYears(3);

            return new CardFactory()?.getInstance(option, cardInfo);
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

        public override string ToString()
        {
            return "Card Payment";
        }
    }
}
