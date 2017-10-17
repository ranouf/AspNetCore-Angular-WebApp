using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Core.Common.Entities
{
  public interface IModificationAudited : IModificationAudited<Guid?>
  {
  }

  public interface IModificationAudited<TPrimaryKey>
  {
    DateTimeOffset? ModifiedAt { get; set; }
    TPrimaryKey ModifiedByUserId { get; set; }
  }
}
