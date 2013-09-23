using System;
using System.Reflection;
using Autofac;
using Autofac.Configuration;
using Autofac.Extras.DynamicProxy2;

using Calendar.Events;
using Calendar.Events.AddPolicy;
using Calendar.Logging;
using Calendar.UI;

namespace Calendar
{
    class Program
    {
        static void Main()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<OptionsDispatcher>()
                            .SingleInstance()
                            .EnableClassInterceptors()
                            .InterceptedBy(typeof(LoggingInterceptor));

            containerBuilder.RegisterInstance(Console.In);

            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                            .Where(type => type.IsAssignableTo<IOption>())
                            .AsImplementedInterfaces()
                            .EnableClassInterceptors()
                            .InterceptedBy(typeof(LoggingInterceptor));

            containerBuilder.Register(c => new Planner(c.Resolve<IEventsRepository>(),
                                                       c.ResolveNamed<IAddPolicy>("shareable"),
                                                       c.ResolveNamed<IAddPolicy>("nonShareable")))
                            .AsImplementedInterfaces();

            containerBuilder.RegisterModule(new ConfigurationSettingsReader("customXmlConfigurationSection"));

            containerBuilder.RegisterType<ExclusiveSchedulePolicy>()
                            .Named<IAddPolicy>("nonShareable");

            containerBuilder.RegisterType<ShareableSchedulePolicy>()
                            .Named<IAddPolicy>("shareable");

            containerBuilder.RegisterType<Logger>().SingleInstance();
            containerBuilder.RegisterType<LoggingInterceptor>();

            using (IContainer container = containerBuilder.Build())
            {
                bool continueRunning = true;
                OptionsDispatcher optionsDispatcher = container.Resolve<OptionsDispatcher>();
                while (continueRunning)
                {
                    continueRunning = optionsDispatcher.ChooseOptionAndRun();
                }
            }
        }
    }
}
