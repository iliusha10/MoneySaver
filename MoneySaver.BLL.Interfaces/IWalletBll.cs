using MoneySaver.DTO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.BLL.Interfaces
{
    public interface IWalletBll
    {
        /// <summary>
        /// Getting from DB all available currencies
        /// </summary>
        /// <returns>List of currencies objects</returns>
        IList<CurrencyDto> GetAllCurrencies();

        /// <summary>
        /// Getting from DB all available wallet types
        /// </summary>
        /// <returns>list of wallet types objects</returns>
        IList<WalletTypeDto> GetAllWalletTypes();
    }
}
