using MoneySaver.DTO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.BLL.Interfaces
{
    public interface ITransactionBll
    {
        /// <summary>
        /// Getting list of transactions from Db for a accountID
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        IList<TransactionListDto> GetUserTransactions(long accountID);
    }
}
