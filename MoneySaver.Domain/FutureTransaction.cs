using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class FutureTransaction : Transaction
    {
        public FutureTransaction(bool applyOnWallet, bool applyDate)
        {
            Apply = applyOnWallet;
            ApplyDate = applyDate;
        }

        [Obsolete]
        protected FutureTransaction()
        {

        }

        public virtual bool ApplyOnWallet { get; protected set; }
        public virtual bool ApplyDate { get; protected set; }
    }
}
