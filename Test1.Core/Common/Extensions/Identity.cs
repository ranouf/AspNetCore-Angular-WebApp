using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Core.Authentication.Entities;

namespace Test1.Core.Common.Extensions
{
  public static class Identity
  {
    public static async Task<User> FindByIdAsync(this UserManager<User> userManger, Guid id)
    {
      return await userManger.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
  }
}
