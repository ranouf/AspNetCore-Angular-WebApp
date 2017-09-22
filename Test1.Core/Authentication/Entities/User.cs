using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Test1.Core.Common.Entities;
using Test1.Core.Sample.Entities;

namespace Test1.Core.Authentication.Entities
{
  public class User : IdentityUser<Guid>, IEntity
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public virtual ICollection<MySample> Samples { get; set; } = new List<MySample>();

    internal User() { }

    public User(string email, string firstName, string lastName)
    {
      UserName = email;
      Email = email;
      FirstName = firstName;
      LastName = lastName;
    }
  }
}
