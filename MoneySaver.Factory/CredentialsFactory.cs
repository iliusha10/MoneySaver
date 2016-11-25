using MoneySaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Factory
{
    class CredentialsFactory
    {
        public static Credentials CreateCredentials(Account account, string userName, string email, string password)
        {
            var user = new Credentials(account, userName, email, password);
            return user;
        }
    }
}
