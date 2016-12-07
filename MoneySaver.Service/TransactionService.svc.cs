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
    public class TransactionService : ITransactionService
    {
         private readonly ITransactionBll _transactionBll;

         public TransactionService(ITransactionBll transactionBll)
        {
            _transactionBll = transactionBll;
        }


         public IList<TransactionListDto> GetUserTransactions(long accountID)
        {
            try
            {
                var transactions = _transactionBll.GetUserTransactions(accountID);
                return transactions;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
