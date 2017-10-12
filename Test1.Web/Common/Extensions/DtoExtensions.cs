using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Web.Common.Dto;

namespace Test1.Web.Common.Extensions
{
  public static class DtoExtensions
  {
    public static async Task<PagedResultDto<TResult>> ToPageResultAsync<T, TResult>(this IQueryable<T> query, PagedRequestDto dto)
    {
      var length = await query.CountAsync();
      var hasNextPage = dto.PageSize.HasValue || (dto.PageIndex + dto.PageSize) < length;

      var data = await query
        .Skip(dto.PageIndex.HasValue && dto.PageSize.HasValue
          ? dto.PageIndex.Value * dto.PageSize.Value
          : 0)
        .Take(dto.PageSize.HasValue
          ? dto.PageSize.Value
          : length)
        .ToListAsync();

      var items = data
          .Select(t => Mapper.Map<T, TResult>(t))
          .ToList();

      return new PagedResultDto<TResult>(length, items, hasNextPage);
    }
  }
}
