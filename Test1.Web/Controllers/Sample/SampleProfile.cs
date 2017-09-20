using AutoMapper;
using Test1.Core.Sample.Entities;
using Test1.Web.Controllers.Sample.Dto;

namespace Test1.Web.Controllers.Sample
{
  public class SampleProfile : Profile
  {
    public SampleProfile()
    {
      CreateMap<MySample, MySampleDto>();
    }
  }
}
