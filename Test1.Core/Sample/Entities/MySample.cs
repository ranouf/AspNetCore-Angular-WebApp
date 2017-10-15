using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Test1.Core.Authentication.Entities;
using Test1.Core.Common.Entities;

namespace Test1.Core.Sample.Entities
{
  public class MySample : Entity, IAudited
  {
    [Required]
    public string Value { get; set; }

    public DateTimeOffset? CreationTime { get; set; }
    public Guid AuthorId { get; set; }
    public virtual User Author { get; set; }
    public DateTimeOffset? LastModificationTime { get; set; }
    public Guid? LastEditorId { get; set; }
    public virtual User LastEditor { get; set; }

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
