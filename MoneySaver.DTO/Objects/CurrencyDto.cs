using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DTO.Objects
{
    public class CurrencyDto
    {
        //public CurrencyDto (long id, string abbrv, string name)
        //{
        //    CurrencyID = id;
        //    Abbreviation = abbrv;
        //    Name = name;
        //}

        public long CurrencyID { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
    }
}
