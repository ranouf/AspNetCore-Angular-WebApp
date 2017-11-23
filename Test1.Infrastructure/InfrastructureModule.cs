using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Test1.Core.Common.Repositories;
using Test1.Core.Common.UnitOWork;
using Test1.Core.Sample;
using Test1.Infrastructure.EntityFramework;
using Test1.Infrastructure.Sample;
using MyRepository = Test1.Core.Common.Repositories;
using MyUnitOWork = Test1.Core.Common.UnitOWork;

namespace Test1.Infrastructure
{
  public class InfrastructureModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces();

      builder.RegisterGeneric(typeof(MyRepository.Repository<>)).As(typeof(MyRepository.IRepository<>));
      builder.RegisterGeneric(typeof(MyRepository.Repository<,>)).As(typeof(MyRepository.IRepository<,>));
      builder.RegisterType<MyUnitOWork.UnitOfWork<AppDbContext>>().As<MyUnitOWork.IUnitOfWork>().InstancePerLifetimeScope();
      builder.RegisterType<AppDbContext>().As<DbContext>().InstancePerLifetimeScope();

      builder.RegisterType<SampleService>().As<ISampleService>();
    }
  }
}
