using System.Runtime.Serialization;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class WalletTypeDto
    {
        public WalletTypeDto(long id, string name)
        {
            WalletTypeID = id;
            Name = name;
        }
        [DataMember]
        public long WalletTypeID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
