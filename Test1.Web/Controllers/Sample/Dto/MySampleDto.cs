using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Web.Controllers.Sample.Dto
{
  public class MySampleDto
  {
    public Guid Id { get; set; }
    [Required]
    public string Value { get; set; }
  }
}
