using System;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy2;

using Calendar.DataAccess;
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
            containerBuilder.RegisterType<OptionsDispatcher>().SingleInstance();
            containerBuilder.RegisterInstance(Console.In);
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                            .Where(type => type.IsAssignableTo<IOption>())
                            .AsImplementedInterfaces();

            containerBuilder.RegisterType<EventsRepository>()
                            .As<IEventsRepository>()
                            .WithParameter("fileName", "calendarData.dat");

            containerBuilder.RegisterType<Planner>()
                            .AsImplementedInterfaces()
                            .EnableClassInterceptors()
                            .InterceptedBy(typeof(LoggingInterceptor));

            containerBuilder.RegisterType<Meeting>()
                            .WithParameter(new ResolvedParameter((pi, c) => pi.ParameterType == typeof(IAddPolicy),
                                                                 (pi, c) => c.Resolve<ExclusiveSchedulePolicy>()))
                            .InstancePerLifetimeScope()
                            .AsSelf()
                            .AsImplementedInterfaces();

            containerBuilder.RegisterType<Todo>()
                            .WithParameter(new ResolvedParameter((pi, c) => pi.ParameterType == typeof(IAddPolicy),
                                                                 (pi, c) => c.Resolve<ShareableSchedulePolicy>()))
                            .InstancePerLifetimeScope()
                            .AsSelf()
                            .AsImplementedInterfaces();

            containerBuilder.RegisterType<ExclusiveSchedulePolicy>()
                            .InstancePerLifetimeScope()
                            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<ShareableSchedulePolicy>()
                            .InstancePerLifetimeScope()
                            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<Logger>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<LoggingInterceptor>();

            using (IContainer container = containerBuilder.Build())
            {
                bool continueRunning = true;
                while (continueRunning)
                {
                    using (ILifetimeScope innerScope = container.BeginLifetimeScope())
                    {
                        OptionsDispatcher optionsDispatcher = innerScope.Resolve<OptionsDispatcher>();
                        continueRunning = optionsDispatcher.ChooseOptionAndRun();
                    }
                }
            }
        }
    }
}
