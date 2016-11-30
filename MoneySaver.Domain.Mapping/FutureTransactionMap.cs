using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class FutureTransactionMap : SubclassMap<FutureTransaction>
    {
        public FutureTransactionMap()
        {
            Map(x => x.).Not.Nullable();
        }
    }
}
