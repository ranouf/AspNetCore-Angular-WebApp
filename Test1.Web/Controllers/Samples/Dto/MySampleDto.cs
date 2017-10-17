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
    public DateTimeOffset CreatedAt { get; set; }
    public string EditorFullname { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string DeleterFullname { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
  }
}
