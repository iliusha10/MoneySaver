using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MoneySaver.Infrastructure
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IRepository))
                .ImplementedBy(typeof(MoneySaver.DAL.Repository))
                .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(ISessionManager))
                .ImplementedBy(typeof(SessionManager))
                .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IAccountRepository))
                .ImplementedBy(typeof(AccountRepository))
                .LifestylePerWebRequest());

        }
    }
}