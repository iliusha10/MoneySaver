using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Account: Entity
    {
        public Account(Credentials user)
        {
            Credentials = user;
            CreatedDate = DateTime.Now;
        }

        [Obsolete]
        protected Account()
        {
        }

        public virtual Credentials Credentials { get; protected set; }
        public virtual DateTime CreatedDate { get; protected set; }
        public virtual IList<Wallet> Wallets { get; protected set; }

        public virtual void AddWallet(Wallet wallet)
        {
            this.Wallets = new List<Wallet> { wallet };
        }
    }
}
