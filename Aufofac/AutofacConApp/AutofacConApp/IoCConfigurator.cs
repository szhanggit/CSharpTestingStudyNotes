using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacConApp
{
    public class IoCConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DemoService>().As<IDemoService>();
            //builder.RegisterType<QuartzWrapper>().As<IQuartzWrapper>().SingleInstance();
            //builder.Register(provider => new JobFactory(provider)).As<IJobFactory>().InstancePerDependency();
            //builder.RegisterType<JobClass>().As<IJob>().InstancePerDependency();
        }
    }
}
