using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DTO.Objects
{
    public class WalletTypeDto
    {
        public WalletTypeDto(long id, string name)
        {
            WalletTypeID = id;
            Name = name;
        }
        public long WalletTypeID { get; set; }
        public string Name { get; set; }
    }
}
