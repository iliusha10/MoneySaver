using MoneySaver.BLL.Interfaces;
using MoneySaver.DAL.Interfaces;
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

        public bool Login(string email, string pass)
        {
            var credentials = _accountDal.GetCredentialsByEmail(email);

            if ((credentials != null) && (credentials.Password == pass))
                return true;
            else return false;

        }
    }
}
