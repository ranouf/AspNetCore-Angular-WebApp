using Microsoft.AspNetCore.Mvc.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace Test1.Web.Common.Filters
{
  public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
  {
    public void Apply(Operation operation, OperationFilterContext context)
    {
      var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
      var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
      var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

      if (operation.Parameters == null)
      {
        operation.Parameters = new List<IParameter>();
      }

      operation.Parameters.Add(new NonBodyParameter
      {
        Name = "Authorization",
        In = "header",
        Description = "access token",
        Required = isAuthorized && !allowAnonymous,
        Type = "string"
      });
    }
  }
}
