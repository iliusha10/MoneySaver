using MoneySaver.DTO.Objects;
using MoneySaver.Domain;
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

        IList<WalletDto> GetUserWallets(string user);

        WalletNamesDto GetDefaultUserWallet(string user);

        /// <summary>
        /// Getting wallet obj by transactionId
        /// </summary>
        /// <param name="tranID"></param>
        /// <returns></returns>
        Wallet GetWalletByTransactionID(long tranID);

        /// <summary>
        /// Get user wallets names from DB
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        IList<WalletNamesDto> GetUserWalletsName(string username);

        /// <summary>
        /// Saving new created wallet in DB
        /// </summary>
        /// <param name="dto"></param>
        void SaveWallet(WalletDto dto, string username);

        /// <summary>
        /// Get Wallet by ID
        /// </summary>
        /// <param name="id"></param>
        WalletDto GetWallet(long id);
    }
}
