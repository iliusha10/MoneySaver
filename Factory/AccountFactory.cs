using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
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
                    var account = new Account(nickname, email, password, currentDate);
                    var wallet = WalletFactory.CreateWallet(account, currency);
                    account.AddWallet(wallet);
                    return account;
                }
            }
            return null;
            
        }
    }
}
