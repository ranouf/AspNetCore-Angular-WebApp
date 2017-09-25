using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test1.Core.Authentication.Entities;
using Test1.Core.Common.Extensions;
using Test1.Core.Runtime.Session;

namespace Test1.Web.Controllers
{
  public class AuthentifiedBaseController : BaseController
  {
    private UserManager<User> _userManager;
    private IAppSession _session;
    private User _currentUser;
    public User CurrentUser
    {
      get
      {
        if (_currentUser == null){
          _currentUser = _userManager.FindByIdAsync(_session.UserId).Result;
        }
        return _currentUser;
      }
    }

    public AuthentifiedBaseController(
    [FromServices] IAppSession session,
    [FromServices]UserManager<User> userManager
    ) : base()
    {
      _userManager = userManager;
      _session = session;
    }
  }
}
