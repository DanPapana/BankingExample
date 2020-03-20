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
            return false;
        }

        public int ExecuteTransaction(CardInfo transactionData)
        {
            return 0;
        }

        public override string ToString()
        {
            return "Visa Payment";
        }
    }
}