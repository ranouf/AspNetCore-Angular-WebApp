using AutoMapper;
using Test1.Core.Authentication.Entities;
using Test1.Web.Controllers.Authorization.Dto;
using Test1.Web.Controllers.Users.Dto;

namespace Test1.Web.Controllers.Authorization
{
  public class AuthorizationProfile : Profile
  {
    public AuthorizationProfile()
    {
      CreateMap<User, UserAuthenticationDto>();
    }
  }
}
