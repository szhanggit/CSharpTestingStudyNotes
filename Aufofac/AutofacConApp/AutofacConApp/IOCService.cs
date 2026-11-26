using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutofacConApp
{
    public class IOCService
    {
        private static readonly Lazy<IOCService> instance = new Lazy<IOCService>(() => new IOCService(), LazyThreadSafetyMode.ExecutionAndPublication);
        private static IServiceProvider _serviceProvider;
        private IOCService()
        { 
        
        }

        static IOCService() { }

        public static IOCService Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public void RegisterServices()
        {
            var collection = new ServiceCollection();
            var builder = new ContainerBuilder();
            builder.RegisterModule(new IoCConfigurator());
            builder.Populate(collection);
            var appContainer = builder.Build();
            _serviceProvider = new AutofacServiceProvider(appContainer);
        }

        public IServiceProvider ServiceProvider { get { return _serviceProvider; } }
        public void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
        public T GetService<T>(out bool flag)
        {
            T obj = _serviceProvider.GetService<T>();
            if (obj != null)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return obj;
        }
    }
}
