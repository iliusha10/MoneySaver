using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneySaver.Models
{
    public class WalletModel
    {
        public long WalletID { get; set; }

        public string WalletName { get; set; }

        public string CurrencyAbbreviation { get; set; }

        public double Amount { get; set; }

        public string WalletTypeName { get; set; }

        public bool DefaultWallet { get; set; }
    }

}