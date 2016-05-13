using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class TransactionMap: EntityMap<Transaction>
    {
        public TransactionMap()
        {
            Map(x => x.Value).Not.Nullable();
            //Map(x => x.WallletID).Not.Nullable();
            //Map(x => x.TransactionCategoryID).Not.Nullable();
            HasOne(x => x.WallletID).LazyLoad();
            HasOne(x => x.TransactionCategoryID).LazyLoad();
        }
    }
}
