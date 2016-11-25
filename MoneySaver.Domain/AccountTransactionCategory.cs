using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class AccountTransactionCategory: Entity
    {
        public AccountTransactionCategory(TransactionCategory categoryid, Account accountid)
        {
            TransactioCategoryID = categoryid;
            UserAcountID = accountid;
        }

        [Obsolete]
        protected AccountTransactionCategory()
        {
        }

        public virtual TransactionCategory TransactioCategoryID { get; protected set; }
        public virtual Account UserAcountID { get; protected set; }
    }
}
