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
            Map(x => x.Comment).Nullable();
            Map(x => x.CreateDate).Not.Nullable();
            References(x => x.Walllet);
            References(x => x.TransactionCategory);
            References(x => x.TransactionSubcategory);
        }
    }
}
