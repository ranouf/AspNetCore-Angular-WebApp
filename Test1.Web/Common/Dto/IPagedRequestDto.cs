using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Web.Common.Dto
{
  public interface IPagedRequestDto
  {
    int? PageSize { get; set; }
    int? PageIndex { get; set; }
  }
}
