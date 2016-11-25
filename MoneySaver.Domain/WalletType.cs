using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Data;

namespace MoneySaver.Domain
{
    public class WalletType:Entity
    {
        public WalletType(string name)
        {
            Name = name;
        }

         [Obsolete]
        protected WalletType()
        {
        }

         public virtual string Name { get; protected set; }
    }
}
