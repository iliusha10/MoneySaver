using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class UserCategoryTypeMap: EntityMap<UserCategoryType>
    {
        public UserCategoryTypeMap()
        {
            References(x => x.UserAcountID);
            References(x => x.TransactioCategoryID);
            Map(x => x.PrimaryCategory).Nullable();
        }
    }
}
