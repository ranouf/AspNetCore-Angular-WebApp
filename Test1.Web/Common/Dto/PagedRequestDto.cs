using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Web.Common.Dto
{
  public class PagedRequestDto
  {
    public int? PageSize { get; set; }
    public int? PageIndex { get; set; }
  }
}
