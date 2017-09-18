using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.Core.Sample;

namespace Test1.Controllers
{
  [Route("api/v1/[controller]")]
  public class SampleController : Controller
  {
    private SampleManager _sampleManager;

    public SampleController(
      SampleManager sampleManager
    )
    {
      _sampleManager = sampleManager;
    }

    // GET api/values
    [HttpGet]
    public string SayHello()
    {
      return _sampleManager.SayHello();
    }
  }
}
