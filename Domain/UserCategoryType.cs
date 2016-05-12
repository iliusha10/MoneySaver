using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserCategoryType: Entity
    {
        public UserCategoryType(TransactionCategory categoryid, Account accountid, bool primary)
        {
            TransactioCategoryID = categoryid;
            UserAcountID = accountid;
            PrimaryCategory = primary;
        }

        [Obsolete]
        protected UserCategoryType()
        {
        }

        public virtual TransactionCategory TransactioCategoryID { get; protected set; }
        public virtual bool PrimaryCategory { get; protected set; }
        public virtual Account UserAcountID { get; protected set; }
    }
}
