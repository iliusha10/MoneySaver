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
        public static Wallet CreateWallet(Account account, Currency currency, string name, WalletType walletType, bool defaultW)
        {
            double amount = 0;
            var wallet = new Wallet(account, currency, amount, name, walletType, defaultW);

            return wallet;
        }
    }
}
