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
            Map(x => x.CreatedDate).Not.Nullable();
            HasMany(x => x.WalletsList).LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.CredentialsList).LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.TransactionCategoryList).LazyLoad().Cascade.All().Inverse();
        }
    }
}
