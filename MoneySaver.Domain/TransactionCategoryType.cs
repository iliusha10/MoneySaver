using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class TransactionCategoryType : Entity
    {
        public TransactionCategoryType(string name)
        {
            Name = name;
        }

        [Obsolete]
        protected TransactionCategoryType()
        {
        }

        public virtual string Name { get; protected set; }
    }
}
