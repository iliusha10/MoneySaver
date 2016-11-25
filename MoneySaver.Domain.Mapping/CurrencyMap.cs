using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class CurrencyMap:EntityMap<Currency>
    {
        public CurrencyMap()
        {
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Abbreviation).Not.Nullable();
        }
    }
}
