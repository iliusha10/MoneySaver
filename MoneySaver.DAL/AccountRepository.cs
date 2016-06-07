using MoneySaver.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DAL
{
    public class AccountRepository: Repository, IAccountRepository
    {
        public AccountRepository (ISessionManager sessionManager): base(sessionManager)
        {
        }
    }
}
