using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class WalletTypeMap:EntityMap<WalletType>
    {
        public WalletTypeMap()
        {
            Map(x => x.Name).Not.Nullable();
        }
    }
}
