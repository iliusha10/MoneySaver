using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using MoneySaver.Service.Interfaces;
using System.ServiceModel;
using MoneySaver.Controllers;

namespace MoneySaver
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAccountService>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(
                    (c) => new ChannelFactory<IAccountService>("WSHttpBinding_IAccountService").CreateChannel()));
            container.RegisterType<IWalletService>(
                 new ContainerControlledLifetimeManager(),
                 new InjectionFactory(
                    (c) => new ChannelFactory<IWalletService>("WSHttpBinding_IWalletService").CreateChannel()));
            container.RegisterType<ITransactionService>(
                 new ContainerControlledLifetimeManager(),
                 new InjectionFactory(
                    (c) => new ChannelFactory<ITransactionService>("WSHttpBinding_ITransactionService").CreateChannel()));
        }
    }
}