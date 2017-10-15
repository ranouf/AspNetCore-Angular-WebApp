using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Test1.Core.Authentication.Entities;
using Test1.Core.Common.Entities;
using Test1.Core.Runtime.Session;
using Test1.Core.Sample.Entities;

namespace Test1.Infrastructure.EntityFramework
{
  public class AppDbContext : IdentityDbContext<User, Role, Guid>
  {
    private IAppSession Session { get; set; }

    public DbSet<MySample> MySamples { get; set; }

    public AppDbContext(DbContextOptions options, IAppSession session) : base(options)
    {
      Session = session;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
      var entries = ChangeTracker.Entries().ToList();
      foreach (var entry in entries)
      {
        switch (entry.State)
        {
          case EntityState.Added:
            SetCreationAuditProperties(entry);
            break;
          case EntityState.Modified:
            SetModificationAuditProperties(entry);
            break;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

    protected virtual void SetCreationAuditProperties(EntityEntry entry)
    {
      if (entry.Entity is ICreationAudited entity)
      {
        if (entity.CreationTime == null)
        {
          entity.CreationTime = DateTime.Now;
        }

        if (Session.UserId.HasValue)
        {
          entity.AuthorId = Session.UserId.Value;
        }
      }
    }

    protected virtual void SetModificationAuditProperties(EntityEntry entry)
    {
      if (entry.Entity is IModificationAudited entity)
      {
        entity.LastModificationTime = DateTime.Now;
        entity.LastEditorId = Session.UserId;
      }
    }
  }
}
