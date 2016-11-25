using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneySaver.Models
{
    public class CurrencyModel
    {
        public CurrencyModel(string abb, string name)
        {
            Abbreviation = abb;
            Name = name;
        }
            public long CurrencyID { get; set; }
            public string Abbreviation { get; set; }
            public string Name { get; set; }
    }
}