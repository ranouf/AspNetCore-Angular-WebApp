using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Web.Controllers.Authentication.Dto
{
  public class RegistrationDto
  {
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
  }
}
