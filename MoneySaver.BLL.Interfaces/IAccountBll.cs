using MoneySaver.DTO;
using MoneySaver.DTO.Objects;
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
        /// <returns>LoginDto</returns>
        LoginDto Login(string email, string pass);

        /// <summary>
        /// Registering user
        /// </summary>
        /// <param name="user"></param>
        void Register(RegisterDto user);
    }
}
