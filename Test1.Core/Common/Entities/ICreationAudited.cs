using System;
using System.Collections.Generic;
using System.Text;
using Test1.Core.Authentication.Entities;

namespace Test1.Core.Common.Entities
{
  public interface ICreationAudited : ICreationAudited<Guid>
  {
  }

  public interface ICreationAudited<TPrimaryKey>
  {
    DateTimeOffset? CreationTime { get; set; }
    TPrimaryKey AuthorId { get; set; }
  }
}
