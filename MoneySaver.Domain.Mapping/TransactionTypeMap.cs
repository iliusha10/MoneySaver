using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class TransactionTypeMap : EntityMap<TransactionType>
    {
        public TransactionTypeMap()
        {
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Value).Not.Nullable();
            Map(x => x.Transfer).Not.Nullable();
            Map(x => x.ShouldBeReturned).Not.Nullable();
        }
    }
}
