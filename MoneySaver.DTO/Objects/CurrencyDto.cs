using System.Runtime.Serialization;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class CurrencyDto
    {
        //public CurrencyDto(long id, string abbrv, string name)
        //{
        //    CurrencyID = id;
        //    Abbreviation = abbrv;
        //    Name = name;
        //}

        [DataMember]
        public long CurrencyID { get; set; }
        [DataMember]
        public string Abbreviation { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
