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
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    public virtual ICollection<MySample> Samples { get; set; } = new List<MySample>();

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
