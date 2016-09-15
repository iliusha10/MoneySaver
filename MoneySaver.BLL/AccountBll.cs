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

namespace MoneySaver.BLL
{
    public class AccountBll:IAccountBll
    {
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
            var account = AccountFactory.CreateAccount(user.UserName, user.Email, user.Password, user.Currency);
        }
    }
}
