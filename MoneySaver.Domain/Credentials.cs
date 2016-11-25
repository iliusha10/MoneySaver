using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Credentials: Entity
    {
        public Credentials(Account account, string userName, string email, string password)
        {
            Account = account;
            UserName = userName;
            Email = email;
            Password = password;
        }


        [Obsolete]
        public Credentials()
        {
        }

        public virtual Account Account { get; set; }
        public virtual string UserName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Password { get; protected set; }
    }
}
