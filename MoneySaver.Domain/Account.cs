using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Account: Entity
    {
        public Account(DateTime date)
        {
            CreatedDate = date;
            //Wallets = new List<Wallet>();
            //Credentials = new List<Wallet>();
        }

        [Obsolete]
        protected Account()
        {
        }

        public virtual IList<Credentials> Credentials { get; protected set; }
        public virtual DateTime CreatedDate { get; protected set; }
        public virtual IList<Wallet> Wallets { get; protected set; }

        public virtual void AddWallet(Wallet wallet)
        {
            Wallets.Add(wallet);
        }

        public virtual void AddUser(Credentials user)
        {
            Credentials.Add(user);
        }
    }
}
