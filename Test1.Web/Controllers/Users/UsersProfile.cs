using AutoMapper;
using Test1.Core.Authentication.Entities;
using Test1.Web.Controllers.Users.Dto;

namespace Test1.Web.Controllers.Users
{
  public class UsersProfile : Profile
  {
    public UsersProfile()
    {
      CreateMap<User, UserDto>();
    }
  }
}
