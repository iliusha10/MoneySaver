using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class WalletMap: EntityMap<Wallet>
    {
        public WalletMap()
        {
            References(x => x.Account);
            Map(x => x.Amount).Not.Nullable();
            Map(x => x.Currency).Not.Nullable();
            Map(x => x.DefaultWallet).Not.Nullable();
        }
        
    }
}
