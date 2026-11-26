using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AutofacConApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            //RegisterServices();
            IOCService.Instance.RegisterServices();

            //var service = _serviceProvider.GetService<IDemoService>();
            bool flag = false;
            var service = IOCService.Instance.GetService<IDemoService>(out flag);
            if (flag)
            {
                service.Display();
            }
            

            //DisposeServices();
            IOCService.Instance.DisposeServices();
        }

        //private static void RegisterServices()
        //{
        //    var collection = new ServiceCollection();
        //    var builder = new ContainerBuilder();
        //    builder.RegisterModule(new IoCConfigurator());
        //    builder.Populate(collection);
        //    var appContainer = builder.Build();
        //    _serviceProvider = new AutofacServiceProvider(appContainer);
        //}

        //private static void DisposeServices()
        //{
        //    if (_serviceProvider == null)
        //    {
        //        return;
        //    }
        //    if (_serviceProvider is IDisposable)
        //    {
        //        ((IDisposable)_serviceProvider).Dispose();
        //    }
        //}
    }
}
