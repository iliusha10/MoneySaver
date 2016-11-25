 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class TransactionCategory: Entity
    {
        public TransactionCategory(string name, Account account)
        {
            CategoryName = name;
            Account = account;
        }

        [Obsolete]
        protected TransactionCategory()
        {
        }

        public virtual string CategoryName { get; protected set; }
        public virtual int OrderNumber { get; protected set; }
        public virtual Account Account { get; protected set; }

    }
}
