using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Core.Common.Entities
{
  public interface IAudited : ICreationAudited, IModificationAudited
  {
  }
}
