using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class WalletDto
    {
        [DataMember]
        public long WalletID { get; set; }
        [DataMember]
        public long CurrencyID { get; set; }
        [DataMember]
        public string CurrencyAbbrviation { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public long WalletTypeId { get; set; }
        [DataMember]
        public string WalletTypeName { get; set; }
        [DataMember]
        public bool DefaultWallet { get; set; }
    }
}
