using MoneySaver.DTO.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MoneySaver.Models
{
    public class TransactionModel
    {

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


        public TransactionDto ConvertModelToDto()
        {
            var dto = new TransactionDto();

            dto.CategoryTypeID = this.SelectedCategoryType;
            dto.WalletID = this.SelectedWallet;
            dto.CategoryID = this.SelectedCategory;
            dto.SubCategoryID = this.SelectedSubCategory;
            dto.Value = this.Value;
            dto.Comment = this.Comment;
            dto.CreateDate = this.CreateDate;

            return dto;
        }
    }

    public class TransactionListModel
    {
        public long TransactionID { get; set; }

        [Display(Name = "Type")]
        public string CategoryTypeName { get; set; }

        [Display(Name = "Wallet")]
        public string WalletName { get; set; }

        //[Display(Name = "Category")]
        //public string CategoryName { get; set; }

        //[Display(Name = "Subcategory Name")]
        //public string SubCategoryName { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryNameConcat { get; set; }

        [Display(Name = "Amount")]
        public double Value { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Date")]
        public DateTime CreateDate { get; set; }

        public TransactionListModel()
        {

        }

        public void ConvertDtoListToModelList(TransactionListDto dto)
        {
            this.TransactionID = dto.TransactionID;
            this.CategoryTypeName = dto.CategoryTypeName;
            this.WalletName = dto.WalletName;
            //this.CategoryName = dto.CategoryName;
            //this.SubCategoryName = dto.SubCategoryName;
            this.Value = dto.Value;
            this.Comment = dto.Comment;
            this.CreateDate = dto.CreateDate;
            this.CategoryNameConcat = String.Format("{0}/{1}", dto.CategoryName, dto.SubCategoryName);
        }
    }
}