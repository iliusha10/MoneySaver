using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class TransactionType : Entity
    {
        public TransactionType(string name, bool value, bool shouldBeReturned, bool transfer)
        {
            Name = name;
            Value = value;
            ShouldBeReturned = shouldBeReturned;
            Transfer = transfer;
        }

        [Obsolete]
        protected TransactionType()
        {
        }

        public virtual string Name { get; protected set; }
        public virtual bool Value { get; protected set; } //If 1 = Income (+)//If 0 = Expence (-)
        public virtual bool ShouldBeReturned { get; protected set; }
        public virtual bool Transfer { get; protected set; }

    }
}
