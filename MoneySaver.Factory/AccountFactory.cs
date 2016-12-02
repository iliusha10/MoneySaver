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
        public static Account CreateAccount(string nickname, string email, string password, string walletName, bool defaultWallet, Currency currency, WalletType walletType, 
            bool insertCategories, IList<TransactionCategoryType> tranCatType)
        {
            var currentDate = DateTime.Now;
            if (email.Contains('@'))
            {
                if (password.Count() > 8)
                {
                    var account = new Account(currentDate);
                    var user = CredentialsFactory.CreateCredentials(account, nickname, email, password);
                    account.AddUser(user);
                    var wallet = WalletFactory.CreateWallet(account, currency, walletName, walletType, defaultWallet);
                    account.AddWallet(wallet);

                    if (insertCategories)
                    {
                        CategoryFactory.CreateDefault(account, tranCatType);
                    }

                    return account;
                }
            }
            return null;
            
        }
    }
}
