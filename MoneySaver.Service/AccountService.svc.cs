using MoneySaver.BLL.Interfaces;
using MoneySaver.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MoneySaver.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountBll _accountBll;

        public AccountService(IAccountBll accountBll)
        {
            _accountBll = accountBll;
        }

        public bool Login(string email, string pass)
        {
            try   
            {  
                return _accountBll.Login(email, pass);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
