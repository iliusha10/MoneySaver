using MoneySaver.BLL.Interfaces;
using MoneySaver.DAL.Interfaces;
using MoneySaver.DTO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.BLL
{
    public class TransactionBll : ITransactionBll
    {
        private readonly IRepository _Dal;
        private readonly ITransactionRepository _transactionDal;

        public AccountBll(ITransactionRepository transactionDal, IRepository dal)
        {
            _transactionDal = transactionDal;
            _Dal = dal;
        }
    
public IList<TransactionListDto> GetUserTransactions(long accountID)
{
 	var list = _transactionDal.GetUserTransactions(long accountID);
}
}
}
