using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Account: Entity
    {
        public Account(string nickname, string email, string password, DateTime createdDate)
        {
            Nickname = nickname;
            Email = email;
            Password = password;
            CreatedDate = createdDate;
        }

        [Obsolete]
        protected Account()
        {
        }

        public virtual string Nickname { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual DateTime CreatedDate { get; protected set; }
        public virtual IList<Wallet> Wallets { get; protected set; }

        public virtual void AddWallet(Wallet wallet)
        {
            this.Wallets = new List<Wallet> { wallet };
        }
    }
}
