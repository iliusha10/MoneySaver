using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Wallet: Entity
    {
        public Wallet ()
        {

        }

        public CurrencyEnum currency{ get; protected set;}
        public double amount { get; protected set; }
        public bool defaultWallet { get; protected set; }
    }
}
