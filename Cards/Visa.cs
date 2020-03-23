using System;

namespace Bank
{
    class Visa : ICard
    {

        private CardInfo cardInfo;

        public Visa() { }
        public Visa(CardInfo cardInfo)
        {
            this.cardInfo = cardInfo;
        }

        public bool CheckPin(int pin)
        {
            if (cardInfo.PIN == pin)
                return true;
            return false;
        }

        public CardInfo ExecuteTransaction(CardInfo transactionData, decimal sendAmount)
        {
            
            if (GetBalance() < sendAmount)
            {
                transactionData.Status = CardInfo.TransactionStatus.NotEnoughFunds;
                return transactionData;
            }

            if (transactionData.ExpiryDate < DateTime.Now)
            {
                transactionData.Status = CardInfo.TransactionStatus.CardExpired;
                return transactionData;
            }

            transactionData.Status = CardInfo.TransactionStatus.Succeeded;
            return transactionData;
        }

        public CardInfo MatchIBAN(string IBAN)
        {
            if (IBAN == cardInfo.IBAN)
            {
                return cardInfo;
            }
            return null;
        }

        public decimal GetBalance()
        {
            if (cardInfo != null)
            {
                return cardInfo.CardBalance;
            }
            return 0;
        }

        public override string ToString()
        {
            return "Visa Payment";
        }
      
    }
}