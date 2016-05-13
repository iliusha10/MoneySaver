using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MoneySaver.Infrastructure
{
    public class CastleControlerFactory: DefaultControllerFactory
    {
        public CastleControlerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
        }

        public IWindsorContainer Container { get; protected set; }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }
            //retrieve the requested controller from castle
            return Container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            //if controler implements IDisposable, clean it up responsably
            var disposableControler = controller as IDisposable;
            if (disposableControler != null)
            {
                disposableControler.Dispose();
            }

            //Inform castle that the controller is no longer required
            Container.Release(controller);
        }
    }
}