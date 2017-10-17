using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Core.Common.Entities
{
  public interface ISoftDelete : ISoftDelete<Guid?>
  {
  }
  public interface ISoftDelete<TPrimaryKey> : IDeletionAudited<TPrimaryKey>
  {
    bool IsDeleted { get; set; }
  }
}
