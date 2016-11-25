using MoneySaver.DTO;
using MoneySaver.DTO.Objects;
using System.ServiceModel;

namespace MoneySaver.Service.Interfaces
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        LoginDto Login(string email, string pass);

        [OperationContract]
        void Register(RegisterDto user);
    }
}
