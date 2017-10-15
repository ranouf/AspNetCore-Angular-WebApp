using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Test1.Core.Common.Entities;
using Test1.Core.Sample.Entities;

namespace Test1.Core.Authentication.Entities
{
  public class User : IdentityUser<Guid>, IEntity
  {
    [Required]
    public string Firstname { get; private set; }
    [Required]
    public string Lastname { get; private set; }
    public string Fullname => $"{Firstname} {Lastname}";

    internal User() { }

    public User(string email, string firstname, string lastname)
    {
      UserName = email;
      Email = email;
      Firstname = firstname;
      Lastname = lastname;
    }
  }
}
