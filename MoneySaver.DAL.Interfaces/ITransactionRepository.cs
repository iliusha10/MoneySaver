using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DAL.Interfaces
{
    public interface ITransactionRepository
    {
        IList<TransactionListDto> GetUserTransactions(long accountID);
    }
}
