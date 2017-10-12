using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Web.Common.Dto
{
  public class PagedResultDto<T>
  {
    public int Length { get; set; }
    public IEnumerable<T> Items { get; set; }
    public bool HasNextPage { get; set; }

    public PagedResultDto(int length, IEnumerable<T> items, bool hasNextPage)
    {
      Length = length;
      Items = items;
      HasNextPage = hasNextPage;
    }
  }
}
