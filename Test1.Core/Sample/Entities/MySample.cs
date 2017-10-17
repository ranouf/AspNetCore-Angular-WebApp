using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Test1.Core.Authentication.Entities;
using Test1.Core.Common.Entities;

namespace Test1.Core.Sample.Entities
{
  public class MySample : Entity, IFullAudited, ISoftDelete
  {
    [Required]
    public string Value { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedByUserId { get; set; }
    [ForeignKey("CreatedByUserId")]
    public virtual User Author { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public Guid? ModifiedByUserId { get; set; }
    [ForeignKey("ModifiedByUserId")]
    public virtual User Editor { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedByUserId { get; set; }
    [ForeignKey("DeletedByUserId")]
    public virtual User Deleter { get; set; }
    public bool IsDeleted { get; set; }

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
