using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using MoneySaver.BLL;
using MoneySaver.BLL.Interfaces;
using MoneySaver.DependancyInjection;
using MoneySaver.DAL.Interfaces;
using MoneySaver.DAL;
using NHibernate;
using MoneySaver.Service.Interfaces;

namespace MoneySaver.Service
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ConfigureUnity();
        }

        protected void Session_Start(object sender, EventArgs e) { }

        protected void Application_BeginRequest(object sender, EventArgs e) { }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) { }

        protected void Application_Error(object sender, EventArgs e) { }

        protected void Session_End(object sender, EventArgs e) { }

        protected void Application_End(object sender, EventArgs e) { }

        private void ConfigureUnity()
        {
            // Configure common service locator to use Unity
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(DIWrapper.Container));

            //DIWrapper.Container.RegisterType<IAccountService, AccountService>();
            //DIWrapper.Container.RegisterType<IWalletService, WalletService>();


            DIWrapper.Container.RegisterType<IAccountBll, AccountBll>();
            DIWrapper.Container.RegisterType<IWalletBll, WalletBll>();
            DIWrapper.Container.RegisterType<ITransactionBll, TransactionBll>();

            InitDAL.Register();

            //DIWrapper.Container.RegisterType<IAccountBll, AccountBll>();
            //DIWrapper.Container.RegisterType<IAccountRepository, AccountRepository>();
            //DIWrapper.Container.RegisterType<IRepository, Repository>();
            //DIWrapper.Container.RegisterType<ISessionManager, SessionManager>();
        }
    }
}