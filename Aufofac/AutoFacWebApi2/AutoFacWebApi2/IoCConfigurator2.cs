using Autofac;
using AutoFacWebApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi2
{
    public class IoCConfigurator2 : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotifyService2>().As<INotificationService2>();
        }
    }
}
