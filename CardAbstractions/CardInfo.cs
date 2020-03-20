using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class CardInfo
    {
        public string CardNumber { get; set; }
        public string CardOwner { get; set; }
        public string CCV { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
