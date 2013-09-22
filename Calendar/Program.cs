using System;

using Autofac;
using Autofac.Core;

using Calendar.DataAccess;
using Calendar.Events;
using Calendar.Events.AddPolicy;
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
            containerBuilder.Register(c => new AddTodoOption(c.Resolve<Func<Todo>>(), c.Resolve<IEventsRepository>()))
                            .As<IOption>();
            containerBuilder.Register(c => new AddMeetingOption(c.Resolve<Func<Meeting>>(), c.Resolve<IEventsRepository>()))
                            .As<IOption>();
            containerBuilder.RegisterType<EventsRepository>().As<IEventsRepository>().WithParameter("fileName", "calendarData.dat");
            containerBuilder.RegisterType<Planner>();

            containerBuilder.RegisterType<Meeting>()
                            .WithParameter(new ResolvedParameter((pi, c) => pi.ParameterType == typeof(IAddPolicy),
                                                                 (pi, c) => c.Resolve<ExclusiveSchedulePolicy>()))
                            .InstancePerLifetimeScope();

            containerBuilder.RegisterType<Todo>()
                            .WithParameter(new ResolvedParameter((pi, c) => pi.ParameterType == typeof(IAddPolicy),
                                                                 (pi, c) => c.Resolve<ShareableSchedulePolicy>()))
                            .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ExclusiveSchedulePolicy>()
                            .InstancePerLifetimeScope()
                            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<ShareableSchedulePolicy>()
                            .InstancePerLifetimeScope()
                            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);


        }
    }
}
