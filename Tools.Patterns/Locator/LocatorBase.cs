using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Patterns.Locator
{
    public abstract class LocatorBase
    {
        protected IServiceProvider Container { get; }

        public LocatorBase()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Container = serviceCollection.BuildServiceProvider();
        }

        protected abstract void ConfigureServices(IServiceCollection serviceCollection);
    }
}
