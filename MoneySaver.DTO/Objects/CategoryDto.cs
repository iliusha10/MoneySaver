using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DTO.Objects
{
    [DataContract]
    public class CategoryDto
    {
        [DataMember]
        public long ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
