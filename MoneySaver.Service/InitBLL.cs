using MoneySaver.BLL;
using MoneySaver.BLL.Interfaces;
using MoneySaver.DependancyInjection;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace MoneySaver.Service
{
    public static class InitBLL
    {
        public static void Register()
        {
            DIWrapper.Container.RegisterType<IAccountBll, AccountBll>();
        }
    }
}