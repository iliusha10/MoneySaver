using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MoneySaver.Models
{
    public class TransactionModel
    {
        //[Display(Name = "User name")]
        //public TransactionCategory TransactionCategory { get; set; }

        [Required(ErrorMessage = "Wallet is required.")]
        [Display(Name = "Wallet")]
        public long SelectedWallets { get; set; }
        public IEnumerable<SelectListItem> AllUsersWallets { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]
        public long SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> AllCategories { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Display(Name = "Amount")]
        public double Value { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Date")]
        public DateTime CreateDate { get; set; }
    }

    public class TransactionListModel
    {
        public long TransactionID { get; set; }

        [Display(Name = "Type")]
        public string CategoryTypeName { get; set; }

        [Display(Name = "Wallet")]
        public string WalletName { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "User name")]
        public string SubCategoryName { get; set; }

        [Display(Name = "Amount")]
        public double Value { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Date")]
        public DateTime CreateDate { get; set; }
    }
}