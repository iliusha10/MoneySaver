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

        public AccountBll(IAccountRepository accountDal)
        {
            _accountDal = accountDal;
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
            var currency = _Dal.GetById<Currency>(user.selectedCurrency);
            var walletType = _Dal.GetById<WalletType>(user.WalletType.WalletTypeID);
            var account = AccountFactory.CreateAccount(user.UserName, user.Email, user.Password, user.WalletName, user.defaultWallet, currency, walletType);
            _Dal.SaveUpdate(account);
            //string nickname, string email, string password, string walletName, bool defaultWallet, Currency currency, WalletType walletType
        }
    }
}
