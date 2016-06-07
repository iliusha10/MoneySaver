using MoneySaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Factory
{
    public static class AccountFactory
    {
        public static Account CreateAccount(string nickname, string email, string password, CurrencyEnum currency)
        {
            var currentDate = DateTime.Now;
            if (email.Contains('@'))
            {
                if (password.Count() > 8)
                {
                    var user = CredentialsFactory.CreateCredentials(nickname, email, password);
                    var account = new Account(user);
                    var wallet = WalletFactory.CreateWallet(account, currency);
                    account.AddWallet(wallet);
                    return account;
                }
            }
            return null;
            
        }
    }
}
