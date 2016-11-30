using MoneySaver.BLL.Interfaces;
using MoneySaver.DAL.Interfaces;
using MoneySaver.DTO;
using MoneySaver.DTO.Objects;
using MoneySaver.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySaver.Domain;

namespace MoneySaver.BLL
{
    public class AccountBll:IAccountBll
    {
        private readonly IRepository _Dal;
        private readonly IAccountRepository _accountDal;

        public AccountBll(IAccountRepository accountDal, IRepository dal)
        {
            _accountDal = accountDal;
            _Dal = dal;
        }

        public LoginDto Login(string email, string pass)
        {
            var credentials = _accountDal.GetCredentialsByEmail(email);

            if ((credentials != null) && (credentials.Password == pass))
                return credentials;
            else return null;
        }

        
        public void Register(RegisterDto user)
        {
            var currency = _Dal.GetById<Currency>(user.CurrencyID);
            var walletType = _Dal.GetById<WalletType>(user.WalletTypeID);
            var account = AccountFactory.CreateAccount(user.UserName, user.Email, user.Password, user.WalletName, user.defaultWallet, currency, walletType, user.InsertCategories);
            _Dal.SaveUpdate(account);
        }
    }
}
