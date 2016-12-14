using System;
using System.Runtime.Serialization;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class TransactionListDto
    {
        [DataMember]
        public long TransactionID { get; set; }

        [DataMember]
        public string CategoryTypeName { get; set; }

        [DataMember]
        public string WalletName { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public string SubCategoryName { get; set; }

        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        public TransactionListDto()
        {
        }
    }
}
