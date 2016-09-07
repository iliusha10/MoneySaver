using System.ServiceModel;

namespace MoneySaver.Service.Interfaces
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        bool Login(string email, string pass);
    }
}
