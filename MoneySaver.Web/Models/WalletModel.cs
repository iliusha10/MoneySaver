using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySaver.Models
{
    public class WalletModel
    {
        public long WalletID { get; set; }

        [Display(Name = "Name")]
        public string WalletName { get; set; }

        [Display(Name = "Currency")]
        public string CurrencyAbbreviation { get; set; }

        public double Amount { get; set; }

        [Display(Name = "Type")]
        public string WalletTypeName { get; set; }

        [Display(Name = "Default")]
        public bool DefaultWallet { get; set; }
    }

    public class CreateWalletModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string WalletName { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Type")]
        public long SelectedWalletType { get; set; }
        public IEnumerable<SelectListItem> AllWalletTypes { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        [Display(Name = "Currency")]
        public long SelectedCurrency { get; set; }
        public IEnumerable<SelectListItem> AllCurrencys { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Display(Name = "Amount")]
        public double Value { get; set; }

        [Display(Name = "Is default wallet")]
        public bool DefaultWallet { get; set; }
    }

}