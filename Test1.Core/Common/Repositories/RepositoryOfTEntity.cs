using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test1.Core.Common.Entities;

namespace Test1.Core.Common.Repositories
{
  public class Repository<TEntity> : Repository<TEntity, Guid>, IRepository<TEntity>
      where TEntity : class, IEntity<Guid>
  {
    public Repository(DbContext dbContext)
        : base(dbContext)
    {
    }
  }
}
