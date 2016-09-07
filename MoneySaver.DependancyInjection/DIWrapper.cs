﻿using Microsoft.Practices.Unity;

namespace MoneySaver.DependancyInjection
{
    public static class DIWrapper
    {
        private static readonly IUnityContainer _container;

        static DIWrapper()
        {
            _container = new UnityContainer();
        }

        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}
