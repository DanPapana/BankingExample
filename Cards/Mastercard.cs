using System;

namespace Bank
{
    class Mastercard : ICard
    {
        private CardInfo cardInfo;
        public Mastercard() { }
        public Mastercard(CardInfo cardInfo)
        {
            this.cardInfo = cardInfo;
        }

        public bool CheckPin(int pin)
        {
            return false;
        }

        public int ExecuteTransaction(CardInfo transactionData)
        {
            return 0;
        }
        public override string ToString()
        {
            return "Mastercard Payment";
        }
    }
}
