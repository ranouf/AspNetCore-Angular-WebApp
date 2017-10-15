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
    DateTimeOffset? LastModificationTime { get; set; }
    TPrimaryKey LastEditorId { get; set; }
  }
}
