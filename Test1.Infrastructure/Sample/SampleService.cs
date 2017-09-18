using System;
using System.Collections.Generic;
using System.Text;
using Test1.Core.Sample;

namespace Test1.Infrastructure.Sample
{
  public class SampleService : ISampleService
  {
    public string SayHello()
    {
      return "Hello";
    }
  }
}
