using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Currency: Entity
    {
        public Currency(string abbreviation, string name)
        {
            Abbreviation = abbreviation;
            Name = name;
        }

        [Obsolete]
        protected Currency()
        {
        }

        public virtual string Abbreviation {get; protected set;}
        public virtual string Name { get; protected set; }
    };
}
