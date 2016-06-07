using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Credentials: Entity
    {
        public Credentials(string nickname, string email, string password)
        {
            Nickname = nickname;
            Email = email;
            Password = password;
        }


        [Obsolete]
        public Credentials()
        {
        }

        public virtual string Nickname { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Password { get; protected set; }
    }
}
