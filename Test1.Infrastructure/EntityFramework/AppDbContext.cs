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

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<MySample>().HasQueryFilter(p => !p.IsDeleted);

      base.OnModelCreating(builder);
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
            if (entry.Entity is ISoftDelete entity)
            {
              if (entity.IsDeleted)
              {
                SetDeletionAuditProperties(entry);
              }
            }
            break;
          case EntityState.Deleted:
            CancelDeletionForSoftDelete(entry);
            SetDeletionAuditProperties(entry);
            break;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

    protected virtual void SetCreationAuditProperties(EntityEntry entry)
    {
      if (entry.Entity is ICreationAudited entity)
      {
        if (entity.CreatedAt == null)
        {
          entity.CreatedAt = DateTime.Now;
        }

        if (Session.UserId.HasValue)
        {
          entity.CreatedByUserId = Session.UserId.Value;
        }
      }
    }

    protected virtual void SetModificationAuditProperties(EntityEntry entry)
    {
      if (entry.Entity is IModificationAudited entity)
      {
        entity.ModifiedAt = DateTime.Now;
        entity.ModifiedByUserId = Session.UserId;
      }
    }

    protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
    {
      if (entry.Entity is ISoftDelete entity)
      {
        entry.State = EntityState.Unchanged;
        entity.IsDeleted = true;
      }
    }

    protected virtual void SetDeletionAuditProperties(EntityEntry entry)
    {
      if (entry.Entity is IDeletionAudited entity)
      {
        if (entity.DeletedAt == null)
        {
          entity.DeletedAt = DateTime.Now;
        }

        if (!entity.DeletedByUserId.HasValue)
        {
          entity.DeletedByUserId = Session.UserId;
        }
      }
    }
  }
}
