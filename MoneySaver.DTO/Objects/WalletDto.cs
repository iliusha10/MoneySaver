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
        //[DataMember]
        //public Currency Currency { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Amount { get; set; }
        //[DataMember]
        //public WalletTypeDto WalletType { get; set; }
        [DataMember]
        public bool DefaultWallet { get; set; }
    }
}
