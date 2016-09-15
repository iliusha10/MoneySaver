using MoneySaver.DTO;
using System.ServiceModel;

namespace MoneySaver.Service.Interfaces
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        LoginDto Login(string email, string pass);

        [OperationContract]
        void Register();
    }
}
