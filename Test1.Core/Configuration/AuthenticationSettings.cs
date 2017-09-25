using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Core.Configuration
{
  public class AuthenticationSettings
  {
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public int ExpirationDurationInDays { get; set; }
  }
}
