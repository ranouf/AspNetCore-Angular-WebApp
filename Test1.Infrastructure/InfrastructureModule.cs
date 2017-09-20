using Autofac;
using System;
using System.Reflection;
using Test1.Core.Common.Repositories;
using Test1.Core.Common.UnitOWork;
using Test1.Core.Sample;
using Test1.Infrastructure.EntityFramework;
using Test1.Infrastructure.Sample;

namespace Test1.Infrastructure
{
  public class InfrastructureModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces();

      builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
      builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));
      builder.RegisterType<UnitOfWork<AppDbContext>>().As<IUnitOfWork>().InstancePerLifetimeScope();

      builder.RegisterType<SampleService>().As<ISampleService>();
    }
  }
}
