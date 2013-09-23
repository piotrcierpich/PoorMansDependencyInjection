using System;
using System.Reflection;
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
      containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                      .Where(type => type.IsAssignableTo<IOption>())
                      .AsImplementedInterfaces();

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

      using (IContainer container = containerBuilder.Build())
      {
        while (true)
        {
          using (ILifetimeScope innerScope = container.BeginLifetimeScope())
          {
            OptionsDispatcher optionsDispatcher = innerScope.Resolve<OptionsDispatcher>();
            optionsDispatcher.ChooseOptionAndRun();
          }
        }
      }

      // ReSharper disable FunctionNeverReturns
    }
    // ReSharper restore FunctionNeverReturns
  }
}
