﻿using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using MoneySaver.DAL;
using MoneySaver.DAL.Interfaces;
using MoneySaver.DependancyInjection;

namespace MoneySaver.BLL
{
    public static class InitDAL
    {
        public static void Register()
        {
            DIWrapper.Container.RegisterType<IAccountRepository, AccountRepository>();
            DIWrapper.Container.RegisterType<IRepository, Repository>();
            DIWrapper.Container.RegisterType<ISessionManager, SessionManager>();
            DIWrapper.Container.RegisterType<ITransactionRepository, TransactionRepository>();
            DIWrapper.Container.RegisterType<IWalletRepository, WalletRepository>();
        }
        
    }
}
