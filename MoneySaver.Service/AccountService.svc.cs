using MoneySaver.BLL.Interfaces;
using MoneySaver.DTO;
using MoneySaver.DTO.Objects;
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

        public LoginDto Login(string email, string pass)
        {
            try   
            {  
                var user = _accountBll.Login(email, pass);
                return user;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public void Register(RegisterDto user)
        {
            try
            {
                _accountBll.Register(user);
                return;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
