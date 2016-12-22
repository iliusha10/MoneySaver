using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneySaver.Models
{
    public class WalletTypeModel
    {
        public long WalletTypeID { get; set; }

        public string Name { get; set; }
    }
}