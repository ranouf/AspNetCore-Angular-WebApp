using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Test1.Core.Sample.Entities;

namespace Test1.Infrastructure.EntityFramework
{
  public class AppDbContext : DbContext
  {
    public DbSet<MySample> MySamples { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
  }
}
