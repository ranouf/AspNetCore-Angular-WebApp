using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.Web.Controllers.Authentication.Dto;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using Test1.Core.Authentication.Entities;
using Test1.Web.Controllers.Users.Dto;
using AutoMapper;

namespace Test1.Web.Controllers.Authorization
{
  [Route("api/v1/[controller]")]
  public class AuthenticationController : Controller
  {
    private UserManager<User> _userManager;

    public AuthenticationController(
      UserManager<User> userManager
    )
    {
      _userManager = userManager;
    }

    // POST api/values
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), 200)]
    public async Task<IActionResult> Login([FromBody]CredentialsDto dto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      // get the user to verifty
      var user = await _userManager.FindByEmailAsync(dto.Email);
      if (user == null)
      {
        return BadRequest();
      }
      if (!await _userManager.CheckPasswordAsync(user, dto.Password))
      {
        return BadRequest();
      }

      return Ok(Mapper.Map<User, UserDto>(user));
    }
  }
}
