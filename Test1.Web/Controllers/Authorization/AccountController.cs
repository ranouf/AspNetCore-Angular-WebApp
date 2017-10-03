using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Test1.Core.Authentication.Entities;
using Test1.Web.Controllers.Authentication.Dto;
using Microsoft.Extensions.Identity.Core;
using Test1.Web.Common.Exceptions;
using System.Linq;

namespace Test1.Web.Controllers.Authorization
{
  [Route("api/v1/[controller]")]
  public class AccountController : Controller
  {
    private UserManager<User> _userManager;

    public AccountController(
      UserManager<User> userManager
    )
    {
      _userManager = userManager;
    }

    // POST api/values
    [HttpPost]
    [ProducesResponseType(typeof(object), 200)]
    public async Task<IActionResult> Register([FromBody]RegistrationDto dto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var userToRegister = new User(
        dto.Email,
        dto.Firstname,
        dto.Lastname
      );

      var result = await _userManager.CreateAsync(userToRegister, dto.Password);

      if (!result.Succeeded)
      {
        throw new ApiException(result.Errors.First().Description);
      }

      return Ok();
    }
  }
}
