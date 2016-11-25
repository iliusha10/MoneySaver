using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class TransactionSubcategoryMap : EntityMap<TransactionSubcategory>
    {
        public TransactionSubcategoryMap()
        {
            Map(x => x.SubcategoryName).Not.Nullable();
            References(x => x.Category);
        }
    }
}
