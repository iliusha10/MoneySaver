using System;
using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace MoneySaver.DependancyInjection.WCF
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses) { }

        public IUnityContainer Container
        {
            get { return DIWrapper.Container; }
        }

        protected override void OnOpening()
        {
            new UnityServiceBehavior(Container).AddToHost(this);
            base.OnOpening();
        }
    }
}
