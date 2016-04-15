using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransactionCategory: Entity
    {
        public virtual string CategoryName { get; protected set; }
        public virtual TransactionTypeEnum CategorType { get; protected set; }


    }
}
