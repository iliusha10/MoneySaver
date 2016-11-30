using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class TransactionSubcategory: Entity
    {
        public TransactionSubcategory(string name, TransactionCategory category)
        {
            SubcategoryName = name;
            Category = category;
        }

        [Obsolete]
        protected TransactionSubcategory()
        {
        }

        public virtual string SubcategoryName { get; protected set; }
        public virtual TransactionCategory Category { get; protected set; }
        public virtual int OrderNumber { get; protected set; }
    }
}
