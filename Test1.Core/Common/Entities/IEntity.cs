using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Test1.Core.Common.Entities
{
  public interface IEntity : IEntity<Guid>
  {
  }

  public interface IEntity<TPrimaryKey>
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    TPrimaryKey Id { get; set; }
  }
}
