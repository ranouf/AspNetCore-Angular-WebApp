using AutoMapper;
using Test1.Core.Sample.Entities;
using Test1.Web.Controllers.Samples.Dto;

namespace Test1.Web.Controllers.Samples
{
  public class SamplesProfile : Profile
  {
    public SamplesProfile()
    {
      CreateMap<MySample, MySampleDto>();
    }
  }
}
