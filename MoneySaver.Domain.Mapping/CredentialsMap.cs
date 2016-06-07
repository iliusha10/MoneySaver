using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class CredentialsMap: EntityMap<Credentials>
    {
        public CredentialsMap()
        {
            Map(x => x.Nickname).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
        }
    }
}
