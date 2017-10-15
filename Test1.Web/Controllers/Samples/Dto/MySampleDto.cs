using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Web.Controllers.Samples.Dto
{
  public class MySampleDto
  {
    public Guid Id { get; set; }
    [Required]
    public string Value { get; set; }
    public string AuthorFullname { get; set; }
    public DateTimeOffset CreationTime { get; set; }
    public string LastEditorFullname { get; set; }
    public DateTimeOffset? LastModificationTime { get; set; }
  }
}
