using System.Runtime.Serialization;

namespace MoneySaver.DTO
{
    [DataContract]
    public class LoginDto
    {
        [DataMember]
        public string Email { get; set; }
        
        [DataMember]
        public string Password { get; set; }
    }
}
