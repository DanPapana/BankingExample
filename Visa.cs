using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Visa : CardTransaction, ICard
    {
        public override void CheckPin()
        {
            Console.WriteLine("Visa pin is 1111");
        }
        public override void ExecuteTransaction()
        {
            Console.WriteLine("Visa execution completed");
        }
    }
}