using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Transaction: Entity
    {
        public Transaction (double value, TransactionCategory category, Wallet walletid)
        {
            Value = value;
            TransactionCategoryID = category;
            WallletID = walletid;
        }

        [Obsolete]
        protected Transaction()
        {

        }

        public virtual double Value { get; protected set; }
        public virtual TransactionCategory TransactionCategoryID { get; protected set; }
        public virtual Wallet WallletID { get; protected set; }
    }
}
