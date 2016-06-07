using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class TransactionMap: EntityMap<Transaction>
    {
        public TransactionMap()
        {
            Map(x => x.Value).Not.Nullable();
            References(x => x.WallletID);
            References(x => x.TransactionCategoryID);
        }
    }
}
