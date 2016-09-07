using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.BLL.Interfaces
{
    public interface IAccountBll
    {
        /// <summary>
        /// Checking user credentials in DB
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns>true/false</returns>
        bool Login(string email, string pass);
    }
}
