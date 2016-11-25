using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Wallet : Entity
    {
        public Wallet(Account account, Currency currency, double amount, string name, WalletType walletType, bool defaultW)
        {
            Account = account;
            Currency = currency;
            Amount = amount;
            Name = name;
            WalletType = walletType;
            DefaultWallet = defaultW;
        }

        [Obsolete]
        protected Wallet()
        {
        }

        public virtual Account Account { get; protected set; }
        public virtual Currency Currency { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual double Amount { get; protected set; }
        public virtual WalletType WalletType { get; protected set; }
        public virtual bool DefaultWallet { get; protected set; }
    }
}
