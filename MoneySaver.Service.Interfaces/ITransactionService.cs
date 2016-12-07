using MoneySaver.DTO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Service.Interfaces
{
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract]
        IList<TransactionListDto> GetUserTransactions(long accountID);
    }
}
