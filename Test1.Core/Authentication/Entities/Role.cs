using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Test1.Core.Common.Entities;

namespace Test1.Core.Authentication.Entities
{
  public class Role : IdentityRole<Guid>, IEntity
  {
  }
}
