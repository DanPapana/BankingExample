using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class ING : BankTransaction, IBank
    {
        public override void ExecuteTransaction()
        {
            Console.WriteLine("ING transaction completed");
        }

        public override void ExecuteTransaction(IBank bankName)
        {
            Console.WriteLine($"{this.ToString()} transaction to {bankName.ToString()} completed");
            
            if (bankName.ToString() == this.ToString())
            {
                Console.WriteLine("No commission fee.");
            } else {
                Console.WriteLine("Commission fee equal to 15");
            }
        }
    }
}
