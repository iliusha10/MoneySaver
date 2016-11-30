using System.Runtime.Serialization;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class RegisterDto
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public long CurrencyID { get; set; }

        [DataMember]
        public string WalletName { get; set; }

        [DataMember]
        public bool defaultWallet { get; set; }

        [DataMember]
        public long WalletTypeID { get; set; }

        [DataMember]
        public bool InsertCategories { get; set; }
    }
}
