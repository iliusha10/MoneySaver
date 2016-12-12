using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class CategoryTypeDto
    {
        public CategoryTypeDto(long id, string name)
        {
            CategoryTypeID = id;
            Name = name;
        }

        [DataMember]
        public long CategoryTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
