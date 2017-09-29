using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Core.Runtime.Session
{
  public interface IAppSession
  {
    Guid? UserId { get; }
  }
}
