using Autofac;
using AutoFacWebApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi2
{
    public class IoCConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotifyService>().As<INotificationService>();
            builder.RegisterType<UsersService>().AsSelf();
        }
    }
}
