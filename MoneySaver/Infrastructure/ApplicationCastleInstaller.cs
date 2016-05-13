using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Repository;
using Repository.Interfaces;
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
                .ImplementedBy(typeof(Repository.Repository))
                .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(ISessionManager))
                .ImplementedBy(typeof(SessionManager))
                .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IAccountRepository))
                .ImplementedBy(typeof(AccountRepository))
                .LifestylePerWebRequest());

            var controllers =
                Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}