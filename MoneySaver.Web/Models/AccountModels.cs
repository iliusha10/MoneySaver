﻿using MoneySaver.DTO.Objects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MoneySaver.Models
{
    //public class UsersContext : DbContext
    //{
    //    public UsersContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public DbSet<UserProfile> UserProfiles { get; set; }
    //}

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "E-mail is required.")]
        [Display(Name = "E-mail")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1.3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid e-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "User name is required.") ]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-mail is required.")]
        [Display(Name = "E-mail")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1.3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid e-mail")]                       
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Give Please your wallet a name.")]
        [Display(Name = "Wallet Name")]
        public string WalletName { get; set; }

        public bool defaultWallet { get; set; }

        //[Required(ErrorMessage = "Select please your wallet type.")]
        [Display(Name = "Wallet Type")]
        public long SelectedWalletType { get; set; }
        public IEnumerable<SelectListItem> AllWalletTypes { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        [Display(Name = "Currency")]
        public long SelectedCurrency { get; set; }
        public IEnumerable<SelectListItem> AllCurrencies { get; set; }

        [Display(Name = "Insert a sample set of categories/subcategories")]
        public bool InsertCategories { get; set; }

        public RegisterModel ()
        {

        }

        public RegisterDto ConvertModelToDto(bool isDefault)
        {
            var newUser = new RegisterDto();

            newUser.UserName = this.UserName;
            newUser.Email = this.Email;
            newUser.Password = this.Password;
            newUser.WalletName = this.WalletName;
            newUser.defaultWallet = isDefault;
            newUser.WalletTypeID = this.SelectedWalletType;
            newUser.CurrencyID = this.SelectedCurrency;
            newUser.InsertCategories = this.InsertCategories;

            return newUser;
        }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

}
