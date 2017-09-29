using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Test1.Core.Authentication.Entities;
using Test1.Core.Sample.Entities;

namespace Test1.Infrastructure.EntityFramework
{
  public class AppDbContext : IdentityDbContext<User, Role, Guid>
  {
    public DbSet<MySample> MySamples { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
  }
}
