using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Web.Common.Dto
{
  public class FilteredSortedPagedRequestDto: IPagedRequestDto, ISortedRequestDto, IFilterRequestDto
  {
    public int? PageSize { get; set; }
    public int? PageIndex { get; set; }
    public string Sort { get; set; }
    public string Direction { get; set; }
    public string Filter { get; set; }
  }
}
