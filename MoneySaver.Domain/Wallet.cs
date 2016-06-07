using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Wallet : Entity
    {
        public Wallet(Account account, CurrencyEnum currency, double amount, bool defaultW)
        {
            Account = account;
            Currency = currency;
            Amount = amount;
            DefaultWallet = defaultW;
        }

        [Obsolete]
        protected Wallet()
        {
        }

        public virtual Account Account { get; protected set; }
        public virtual CurrencyEnum Currency { get; protected set; }
        public virtual double Amount { get; protected set; }
        public virtual bool DefaultWallet { get; protected set; }
    }
}
