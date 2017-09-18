using Autofac;
using System;
using System.Reflection;
using Test1.Core.Sample;
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

      builder.RegisterType<SampleService>().As<ISampleService>();
    }
  }
}
