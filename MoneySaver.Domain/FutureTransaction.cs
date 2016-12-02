using System;

namespace MoneySaver.Domain
{
    public class FutureTransaction : Transaction
    {
        public FutureTransaction(bool applyOnWallet, bool applyDate)
        {
            ApplyOnWallet = applyOnWallet;
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
