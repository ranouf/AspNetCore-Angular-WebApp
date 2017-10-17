using System;
using System.Collections.Generic;
using System.Text;
using Test1.Core.Authentication.Entities;

namespace Test1.Core.Common.Entities
{
  public interface IDeletionAudited : IDeletionAudited<Guid?>
  {
  }

  public interface IDeletionAudited<TPrimaryKey>
  {
    DateTimeOffset? DeletedAt { get; set; }
    TPrimaryKey DeletedByUserId { get; set; }
  }
}
