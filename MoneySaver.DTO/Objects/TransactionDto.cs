using System;
using System.Runtime.Serialization;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class TransactionDto
    {
        [DataMember]
        public long CategoryTypeID { get; set; }

        [DataMember]
        public long WalletID { get; set; }

        [DataMember]
        public long CategoryID { get; set; }

        [DataMember]
        public long SubCategoryID { get; set; }

        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }
    }
}
