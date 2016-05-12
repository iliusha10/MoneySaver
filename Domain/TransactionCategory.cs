using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransactionCategory: Entity
    {
        public TransactionCategory(string name, TransactionTypeEnum type)
        {
            CategoryName = name;
            CategoryType = type;
        }

        [Obsolete]
        protected TransactionCategory()
        {
        }

        public virtual string CategoryName { get; protected set; }
        public virtual TransactionTypeEnum CategoryType { get; protected set; }
    }
}
