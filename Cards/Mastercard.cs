using System;

namespace Bank
{
    class Mastercard : CardTransaction, ICard
    {
        public override void CheckPin()
        {
            Console.WriteLine("Mastercard pin is 3412");
        }

        public override void ExecuteTransaction()
        {
            Console.WriteLine("Mastercard execution completed");
        }
    }
}
