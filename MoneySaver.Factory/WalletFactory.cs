using MoneySaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Factory
{
    public static class WalletFactory
    {
        public static Wallet CreateWallet(Account account, CurrencyEnum currency)
        {
            double amount = 0;
            bool defaultWallet = true;
            var wallet = new Wallet(account, currency, amount, defaultWallet);

            return wallet;
        }
    }
}
