using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Core.Common.Entities
{
  public interface IFullAudited : ICreationAudited, IModificationAudited,  IDeletionAudited
  {
  }
}
