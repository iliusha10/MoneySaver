using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class AccountMap: EntityMap<Account>
    {
        public AccountMap()
        {
            References(x => x.Credentials).Cascade.All();
            Map(x => x.CreatedDate).Not.Nullable();
            HasMany(x => x.Wallets).LazyLoad().Cascade.All().Inverse();
        }
    }
}
