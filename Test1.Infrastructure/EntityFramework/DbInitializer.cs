using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1.Core.Sample.Entities;

namespace Test1.Infrastructure.EntityFramework
{
  /// <summary>
  /// Based on Microsft Documentation (https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro)
  /// </summary>
  public static class DbInitializer
  {
    public static void Initialize(AppDbContext context)
    {
      context.Database.EnsureCreated();

      // Look for any sample.
      if (context.MySamples.Any())
      {
        return;   // DB has been seeded
      }

      var mySamples = new MySample[]
      {
            new MySample{Value="Sample 1"},
            new MySample{Value="Sample 2"},
            new MySample{Value="Sample 3"},
      };
      foreach (var mySample in mySamples)
      {
        context.MySamples.Add(mySample);
      }
      context.SaveChanges();
    }
  }
}
