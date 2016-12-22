using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class WalletNamesDto
    {
        [DataMember]
        public long WalletID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool DefaultWallet { get; set; }

        //public WalletNamesDto ()
        //{

        //}
    }
}
