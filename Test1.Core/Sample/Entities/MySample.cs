using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Test1.Core.Authentication.Entities;
using Test1.Core.Common.Entities;

namespace Test1.Core.Sample.Entities
{
  public class MySample : Entity
  {
    [Required]
    public string Value { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = new User();

    internal MySample() { }

    public MySample(string value)
    {
      Value = value;
    }
    public void Update(string value)
    {
      Value = value;
    }
  }
}
