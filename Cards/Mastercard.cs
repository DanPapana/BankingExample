using System;

namespace Bank
{
    class Mastercard : ICard
    {
        public bool CheckPin(int pin)
        {
            return false;
        }

        public int ExecuteTransaction(CardInfo transactionData)
        {
            return 0;
        }
    }
}
