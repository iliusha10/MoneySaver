using MoneySaver.DTO.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MoneySaver.Models
{
    public class CreateTransactionModel
    {
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Wallet is required.")]
        [Display(Name = "Wallet")]
        public long SelectedWallet { get; set; }
        public IEnumerable<SelectListItem> AllUsersWallets { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Type")]
        public long SelectedCategoryType { get; set; }
        public IEnumerable<SelectListItem> AllCategoriesTypes { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]
        public long SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> AllCategories { get; set; }

        [Display(Name = "Subcategory")]
        public long SelectedSubCategory { get; set; }
        public IEnumerable<SelectListItem> AllSubCategories { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Display(Name = "Amount")]
        public double Value { get; set; }

        public string Comment { get; set; }

    }

    public class TransactionListModel
    {
        public long TransactionID { get; set; }

        [Display(Name = "Type")]
        public string CategoryTypeName { get; set; }

        [Display(Name = "Wallet")]
        public string WalletName { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryNameConcat { get; set; }

        [Display(Name = "Amount")]
        public double Value { get; set; }

        public string Comment { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}" )]
        [Display(Name = "Date")]
        public DateTime CreateDate { get; set; }

    }
}