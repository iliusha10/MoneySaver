using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class AccountMap: EntityMap<Account>
    {
        public AccountMap()
        {
            Map(x => x.Nickname).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.CreatedDate).Not.Nullable();
            HasMany(x => x.Wallets).LazyLoad().Cascade.All().Inverse();
        }
    }
}
