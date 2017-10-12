using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Web.Common.Dto
{
  public interface ISortedRequestDto
  {
    string Sort { get; set; }
    string Direction { get; set; }
  }
}
