using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
